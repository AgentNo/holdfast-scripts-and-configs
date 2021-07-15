using HoldfastSharedMethods;
using UnityEngine;
using UnityEngine.UI;

public class TestScriptMod : IHoldfastSharedMethods {
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
        if (uCaseText.Contains("uwu") || uCaseText.Contains("owo")) {
            if (f1MenuInputField != null) {
                var rcCommand = string.Format("serverAdmin slap {0} {1} {2}", playerId, damage, reason);
                f1MenuInputField.onEndEdit.Invoke(rcCommand);
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
            if (splitData[0] == "2539292336") {
                //the second variable should be the variable type
                if (splitData[1] == "owo_slap_damage") {
                    //and the third variable should be the variable value
                    if (!int.TryParse(splitData[2], out damage)) {
                        Debug.Log("Tried parsing owo_slap_damage but invalid format was found.");
                    }
                }
                //similarly, reason is the variable type
                else if (splitData[1] == "owo_slap_reason") {
                    //fill the reason using the variable value
                    reason = splitData[2];
                }
            }
        }
        Debug.Log("'No UwU/OwO Allowed! loaded with custom parameters'");
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
}
