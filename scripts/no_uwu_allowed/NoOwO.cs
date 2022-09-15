using HoldfastSharedMethods;
using UnityEngine;
using UnityEngine.UI;

public class NoOwO : IHoldfastSharedMethods {
    private InputField f1MenuInputField;
    private int damage = 5;
    private string reason = "No uwu allowed here >:(";

    public void OnIsServer(bool server) {
        //Get all the canvas items in the game
        var canvases = Resources.FindObjectsOfTypeAll<Canvas>();
        for (int i = 0; i < canvases.Length; i++) {
            //Find the one that's called "Game Console Panel"
            if (string.Compare(canvases[i].name, "Game Console Panel", true) == 0) {
                //Inside this, now we need to find the input field where the player types messages.
                f1MenuInputField = canvases[i].GetComponentInChildren<InputField>(true);
                if (f1MenuInputField != null) {
                    Debug.Log("No OwO/UwU Allowed!: Found the Game Console Panel");
                } else {
                    Debug.Log("No OwO/UwU Allowed!: Game Console Panel not found.This mod may not work correctly!");
                }
                break;
            }
        }
    }

    public void OnTextMessage(int playerId, TextChatChannel channel, string text) {
        string uCaseText = text.ToLower();
        if (uCaseText.Contains("uwu") || uCaseText.Contains("owo")) {
            // If UwU/OwO is found in the message, slap the player and send a PM
            if (f1MenuInputField != null) {
                f1MenuInputField.onEndEdit.Invoke(string.Format("serverAdmin slap {0} {1} {2}", playerId, damage, reason));
                f1MenuInputField.onEndEdit.Invoke(string.Format("serverAdmin privateMessage {0} {1}", playerId, reason));
            }
        }
    }

    public void PassConfigVariables(string[] value) {
        for (int i = 0; i < value.Length; i++) {
            var splitData = value[i].Split(':');
            if (splitData.Length != 3) {
                continue;
            }

            if (splitData[0] == "no_owo") {
                // Values for slap damage and slap reason
                if (splitData[1] == "owo_slap_damage") {
                    if (!int.TryParse(splitData[2], out damage)) {
                        Debug.Log("Tried parsing owo_slap_damage but invalid format was found.");
                    }
                }
                else if (splitData[1] == "owo_slap_reason") {
                    reason = splitData[2];
                }
            }
        }
        Debug.Log("'No UwU/OwO Allowed!' loaded with custom parameters");
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

    public void OnPlayerJoined(int playerId, ulong steamId, string playerName, string regimentTag, bool isBot) {

    }

    public void OnPlayerLeft(int playerId) {

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

    public void OnOfficerOrderStart(int officerPlayerId, HighCommandOrderType highCommandOrderType, Vector3 orderPosition, float orderRotationY, int voicePhraseRandomIndex) {
    }

    public void OnOfficerOrderStop(int officerPlayerId, HighCommandOrderType highCommandOrderType) {
    }
}
