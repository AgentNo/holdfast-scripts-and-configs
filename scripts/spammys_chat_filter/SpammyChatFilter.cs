using HoldfastSharedMethods;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SpammyChatFilter : IHoldfastSharedMethods {
    private InputField f1MenuInputField;
    private int damage = 5;
    private int mute_threshold = 3; 
    private string reason = "Chat Filter: Please refrain from saying banned words in chat.";
    private string mute_message = "Chat Filter: You have now been temp muted from text chat.";
    private List<string> banned_words = new List<string>()
    {
        "***"
    }; //The three stars will capture all the currently censored words in-game (for example, 'nazi' etc.). These are censored before the message is sent, so the actual words themselves cannot be slapped.
    private Dictionary<int, int> playerSlapList = new Dictionary<int, int>(); //Maps playerId and the times the player has been slapped

    public void OnIsServer(bool server) {
        //Get all the canvas items in the game
        var canvases = Resources.FindObjectsOfTypeAll<Canvas>();
        for (int i = 0; i < canvases.Length; i++) {
            //Find the one that's called "Game Console Panel"
            if (string.Compare(canvases[i].name, "Game Console Panel", true) == 0) {
                //Inside this, now we need to find the input field where the player types messages.
                f1MenuInputField = canvases[i].GetComponentInChildren<InputField>(true);
                if (f1MenuInputField != null) {
                    Debug.Log("Found the Game Console Panel");
                } else {
                    Debug.Log("Game Console Panel not found");
                }
                break;
            }
        }
    }

    public void OnTextMessage(int playerId, TextChatChannel channel, string text) {
        // First convert it to lower case, this prevents players circumventing it with odd casing
        string uCaseText = text.ToLower();
        foreach(string banned_word in banned_words) {
            if (uCaseText.Contains(banned_word)) {
                if (f1MenuInputField != null) {
                    var rcSlapCommand = string.Format("serverAdmin slap {0} {1} {2}", playerId, damage, reason);
                    f1MenuInputField.onEndEdit.Invoke(rcSlapCommand);
                    var rcWarnCommand = string.Format("serverAdmin privateMessage {0} {1}", playerId, reason);
                    f1MenuInputField.onEndEdit.Invoke(rcWarnCommand);

                    //Increment the player's slap count
                    int slapCount;
                    playerSlapList.TryGetValue(playerId, out slapCount);
                    playerSlapList[playerId] = slapCount + 1;
                    // Check if the player needs to be muted
                    if (playerSlapList[playerId] == mute_threshold) {
                        // Temp mute the player - this only needs to happen once per round
                        var rcMuteCommand = string.Format("serverAdmin chatMute {0} {1}", playerId, "You are now auto-temp muted.");
                        f1MenuInputField.onEndEdit.Invoke(rcMuteCommand);
                    }
                    break; // Break so the entire list is not parsed every time - don't punish players for more than one word
                }
            }
        }
    }

    public void PassConfigVariables(string[] value) {
        for (int i = 0; i < value.Length; i++) {
            var splitData = value[i].Split(':');
            if (splitData.Length != 3) {
                continue;
            }

            //so first variable should be the mod id
            if (splitData[0] == "2549637575") {
                //the second variable should be the variable type
                if (splitData[1] == "schat_filter_slap_damage") {
                    //and the third variable should be the variable value
                    if (!int.TryParse(splitData[2], out damage)) {
                        Debug.Log("Tried parsing slap_damage but invalid format was found.");
                    }
                }
                //similarly, reason is the variable type
                else if (splitData[1] == "schat_filter_slap_reason") {
                    //fill the reason using the variable value
                    reason = splitData[2];
                } else if (splitData[1] == "schat_filter_banned_word") {
                    // Add a banned word to the list
                    banned_words.Add(splitData[2]);
                } else if (splitData[1] == "schat_filter_mute_limit") {
                    // Change how many slaps before user is muted
                    if (!int.TryParse(splitData[2], out mute_threshold)) {
                        Debug.Log("Tried parsing mute_threshold but invalid format was found.");
                    }
                }
            }
        }
    }

    public void OnPlayerJoined(int playerId, ulong steamId, string playerName, string regimentTag, bool isBot) {
        // Add the player to the dictionary
        playerSlapList.Add(playerId, 0);
    }

    public void OnPlayerLeft(int playerId) {
        // If a player has left, remove them from the dictionary
        if (playerSlapList.ContainsKey(playerId)) {
            playerSlapList.Remove(playerId);
        }
    }

    public void OnSyncValueState(int value) {
    }

    public void OnUpdateSyncedTime(double time) {
    }

    public void OnUpdateElapsedTime(float time) {
    }

    public void OnUpdateTimeRemaining(float time) {
    }

    public void OnIsClient(bool client, ulong steamId) {
    }

    public void OnDamageableObjectDamaged(GameObject damageableObject, int damageableObjectId, int shipId, int oldHp, int newHp) {
    }

    public void OnPlayerHurt(int playerId, byte oldHp, byte newHp, EntityHealthChangedReason reason) {
    }

    public void OnPlayerKilledPlayer(int killerPlayerId, int victimPlayerId, EntityHealthChangedReason reason, string additionalDetails) {
    }

    public void OnPlayerShoot(int playerId, bool dryShot) {
    }

    public void OnPlayerSpawned(int playerId, int spawnSectionId, FactionCountry playerFaction, PlayerClass playerClass, int uniformId, GameObject playerObject) {
    }

    public void OnScorableAction(int playerId, int score, ScorableActionType reason) {
    }

    public void OnRoundDetails(int roundId, string serverName, string mapName, FactionCountry attackingFaction, FactionCountry defendingFaction, GameplayMode gameplayMode, GameType gameType) {
    }

    public void OnPlayerBlock(int attackingPlayerId, int defendingPlayerId) {
    }

    public void OnPlayerMeleeStartSecondaryAttack(int playerId) {
    }

    public void OnPlayerWeaponSwitch(int playerId, string weapon) {
    }

    public void OnCapturePointCaptured(int capturePoint) {
    }

    public void OnCapturePointOwnerChanged(int capturePoint, FactionCountry factionCountry) {
    }

    public void OnCapturePointDataUpdated(int capturePoint, int defendingPlayerCount, int attackingPlayerCount) {
    }

    public void OnRoundEndFactionWinner(FactionCountry factionCountry, FactionRoundWinnerReason reason) {
    }

    public void OnRoundEndPlayerWinner(int playerId) {
    }

    public void OnPlayerStartCarry(int playerId, CarryableObjectType carryableObject) {
    }

    public void OnPlayerEndCarry(int playerId) {
    }

    public void OnPlayerShout(int playerId, CharacterVoicePhrase voicePhrase) {
    }

    public void OnInteractableObjectInteraction(int playerId, int interactableObjectId, GameObject interactableObject, InteractionActivationType interactionActivationType, int nextActivationStateTransitionIndex) {
    }

    public void OnEmplacementPlaced(int itemId, GameObject objectBuilt, EmplacementType emplacementType) {
    }

    public void OnEmplacementConstructed(int itemId) {
    }

    public void OnBuffStart(int playerId, BuffType buff) {
    }

    public void OnBuffStop(int playerId, BuffType buff) {
    }

    public void OnShotInfo(int playerId, int shotCount, Vector3[][] shotsPointsPositions, float[] trajectileDistances, float[] distanceFromFiringPositions, float[] horizontalDeviationAngles, float[] maxHorizontalDeviationAngles, float[] muzzleVelocities, float[] gravities, float[] damageHitBaseDamages, float[] damageRangeUnitValues, float[] damagePostTraitAndBuffValues, float[] totalDamages, Vector3[] hitPositions, Vector3[] hitDirections, int[] hitPlayerIds, int[] hitDamageableObjectIds, int[] hitShipIds, int[] hitVehicleIds) {
    }

    public void OnVehicleSpawned(int vehicleId, FactionCountry vehicleFaction, PlayerClass vehicleClass, GameObject vehicleObject, int ownerPlayerId) {
    }

    public void OnVehicleHurt(int vehicleId, byte oldHp, byte newHp, EntityHealthChangedReason reason) {
    }

    public void OnPlayerKilledVehicle(int killerPlayerId, int victimVehicleId, EntityHealthChangedReason reason, string details) {
    }

    public void OnShipSpawned(int shipId, GameObject shipObject, FactionCountry shipfaction, ShipType shipType, int shipNameId) {
    }

    public void OnShipDamaged(int shipId, int oldHp, int newHp) {
    }

    public void OnAdminPlayerAction(int playerId, int adminId, ServerAdminAction action, string reason) {
    }

    public void OnConsoleCommand(string input, string output, bool success) {
    }

    public void OnRCLogin(int playerId, string inputPassword, bool isLoggedIn) {
    }

    public void OnRCCommand(int playerId, string input, string output, bool success) {
    }

    public void OnPlayerPacket(int playerId, byte? instance, Vector3? ownerPosition, double? packetTimestamp, Vector2? ownerInputAxis, float? ownerRotationY, float? ownerPitch, float? ownerYaw, PlayerActions[] actionCollection, Vector3? cameraPosition, Vector3? cameraForward, ushort? shipID, bool swimming) {
    }

    public void OnVehiclePacket(int vehicleId, Vector2 inputAxis, bool shift, bool strafe, PlayerVehicleActions[] actionCollection) {
    }

    public void OnOfficerOrderStart(int officerPlayerId, OfficerOrderType officerOrderType, Vector3 orderPosition, float orderRotationY, int voicePhraseRandomIndex) {
    }

    public void OnOfficerOrderStop(int officerPlayerId, OfficerOrderType officerOrderType) {
    }
}