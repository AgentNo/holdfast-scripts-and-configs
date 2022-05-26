// Freeze!
// Freeze all players in position until unfrozen by an admin.
// Commands are placed in any chat, but can only be used by the authorised users passed in the config as a comma-delimited set of values.
// This is the steamID of each player (SteamId64), which is mapped to user id when the user joins the round
// Obviously, for security reasons, DO NOT put SteamIds into the git repo!

using HoldfastSharedMethods;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FreezerScript : IHoldfastSharedMethods {
    private InputField f1MenuInputField;
    private Dictionary<int, ulong> authorisedUsers = new Dictionary<int, ulong>(); //Maps playerId and steamId for authorised users
    private List<string> authUsersSteamIds = new List<string>();

    public void OnIsServer(bool server) {
        //Get all the canvas items in the game
        var canvases = Resources.FindObjectsOfTypeAll<Canvas>();
        for (int i = 0; i < canvases.Length; i++) {
            //Find the one that's called "Game Console Panel"
            if (string.Compare(canvases[i].name, "Game Console Panel", true) == 0) {
                //Inside this, now we need to find the input field where the player types messages.
                f1MenuInputField = canvases[i].GetComponentInChildren<InputField>(true);
                if (f1MenuInputField != null) {
                    Debug.Log("Freeze!: Found the Game Console Panel");
                } else {
                    Debug.Log("Freeze!: Game Console Panel not found. This mod may not work correctly!");
                }
                break;
            }
        }
    }

    public void OnTextMessage(int playerId, TextChatChannel channel, string text) {
        string message = text.ToLower();
        if (authorisedUsers.ContainsKey(playerId)) {
            if (message.Equals("!freeze")) {
                if (f1MenuInputField != null) {
                    // Freeze players in place and grant god mode
                    f1MenuInputField.onEndEdit.Invoke("set characterRunSpeed 0");
                    f1MenuInputField.onEndEdit.Invoke("set characterWalkSpeed 0");
                    f1MenuInputField.onEndEdit.Invoke("set characterGodMode 1");
                }
            } else if (message.Equals("!unfreeze")) {
                if (f1MenuInputField != null) {
                    // Unfreeze players and return to normal hp
                    f1MenuInputField.onEndEdit.Invoke("set characterRunSpeed 1");
                    f1MenuInputField.onEndEdit.Invoke("set characterWalkSpeed 1");
                    f1MenuInputField.onEndEdit.Invoke("set characterGodMode 0");
                }
            }
        }
    }

    public void PassConfigVariables(string[] value) {
        Debug.Log("Freeze!: Fetching steam ID values from config...");
        for (int i = 0; i < value.Length; i++) {
            var splitData = value[i].Split(':');
            if (splitData.Length != 3) {
                continue;
            }

            if (splitData[0] == "freeze") {
                if (splitData[1] == "authorised_users") {
                    // In this case, our value is a list of steamIds for authorised users
                    Debug.Log("Freeze!: Found steam IDs in config, added to whitelist");
                    authUsersSteamIds = splitData[2].Split(',').ToList();
                }
            }
        }
        Debug.Log("Freeze!: Mod loaded with custom parameters successfully!");
    }

    public void OnPlayerJoined(int playerId, ulong steamId, string playerName, string regimentTag, bool isBot) {
        // If the user's steam ID is part of the freeze_authorised_users argument, create a mapping in the dictionary to allow for commands to be issued
        if (authUsersSteamIds.Contains(Convert.ToString(steamId)) && !isBot) {
            Debug.Log("Freeze!: Authorised user " + playerId + " added to whitelist (joined server)");
            authorisedUsers.Add(playerId, steamId);
        }
    }

    public void OnPlayerLeft(int playerId) {
        // If the user is in the autorised list, remove them
        if (authorisedUsers.ContainsKey(playerId)) {
            Debug.Log("Freeze!: Authorised user " + playerId + " removed from whitelist (left server)");
            authorisedUsers.Remove(playerId);
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

    public void OnRCCommand(int playerId, string input, string output, bool success) {
    }

    public void OnRCLogin(int playerId, string inputPassword, bool isLoggedIn) {
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