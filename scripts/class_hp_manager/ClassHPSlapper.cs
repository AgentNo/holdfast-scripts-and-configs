// Class HP Slapper
// Allows for custom HP overrides based on a player's class. For example, an admin may wish to give all grenadiers a 100HP boost.
// This is not possible in current Holdfast admin tools.
// Arguments are passed via the config.

using HoldfastSharedMethods;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BlankInterface : IHoldfastSharedMethods {
    private InputField f1MenuInputField;
    private Dictionary<PlayerClass, int> attackingClassHpOverrides = new Dictionary<PlayerClass, int>();
    private Dictionary<PlayerClass, int> defendingClassHpOverrides = new Dictionary<PlayerClass, int>();
    private FactionCountry FACTION_ATTACKING;
    private FactionCountry FACTION_DEFENDING;
    private float timeRemaining;

    public void OnIsServer(bool server) {
        Debug.Log("CHPM: Starting load...");
        //Get all the canvas items in the game
        var canvases = Resources.FindObjectsOfTypeAll<Canvas>();
        for (int i = 0; i < canvases.Length; i++) {
            if (string.Compare(canvases[i].name, "Game Console Panel", true) == 0) {
                f1MenuInputField = canvases[i].GetComponentInChildren<InputField>(true);
                if (f1MenuInputField != null) {
                    Debug.Log("CHPM: Found the Game Console Panel");
                } else {
                    Debug.Log("CHPM: Game Console Panel not found! This may cause stability issues.");
                }
                break;
            }
        }
    }

    public void PassConfigVariables(string[] value) {
        for (int i = 0; i < value.Length; i++) {
            var splitData = value[i].Split(':');
            if (splitData.Length != 3) {
                continue;
            }

            if (splitData[0] == "CHPM") {
                Debug.Log("CHPM: Found a variable, parsing argument...");
                if (splitData[1] == "chpm_class_override") {
                    getClassHpOverrideArgs(splitData);
                } else {
                    Debug.Log(string.Format("CHPM: Syntax error parsing variable: '{0}'", splitData[1]));
                }
            }
        }
    }

    public void OnPlayerSpawned(int playerId, int spawnSectionId, FactionCountry playerFaction, PlayerClass playerClass, int uniformId, GameObject playerObject) {
        if (FACTION_ATTACKING == playerFaction) {
            if (attackingClassHpOverrides.ContainsKey(playerClass)) {
                overrideClassHp(playerId, playerClass, playerFaction, attackingClassHpOverrides[playerClass]);
            }
        } else if (FACTION_DEFENDING == playerFaction) {
            if (defendingClassHpOverrides.ContainsKey(playerClass)) {
                overrideClassHp(playerId, playerClass, playerFaction, defendingClassHpOverrides[playerClass]);
            }
        } else {
            Debug.Log("CHPM: Error comparing player faction to server faction. If you see this, contact the mod creator for assistance.");
        }
    }

    private void getClassHpOverrideArgs(string[] splitData) {
        string[] classArg = splitData[2].Split(',');
        if (classArg.Length == 3) {
            Debug.Log(string.Format("CHPM: Attempting to parse class HP override for {0} class {1}", classArg[0], classArg[1]));

            PlayerClass playerClass;
            if (System.Enum.TryParse<PlayerClass>(classArg[1], out playerClass)) {
                int hpOverride;
                Debug.Log("CHPM: Attempting to parse HP override...");
                if (int.TryParse(classArg[2], out hpOverride)) {
                    setUpClassHpOverrideRuleFromArgument(classArg, playerClass, hpOverride);
                } else {
                    Debug.Log(string.Format("CHPM: Error parsing HP override for class {0} - ensure it is a valid number!", classArg[1]));
                }
            } else {
                Debug.Log(string.Format("CHPM: Error parsing HP override for class {0} - class enum is not valid", classArg[1]));
            }
        } else {
            Debug.Log(string.Format("CHPM: Error parsing parameter - malformed argument passed."));
        }
    }

    private void setUpClassHpOverrideRuleFromArgument(string[] classArg, PlayerClass playerClass, int hpOverride) {
        if (classArg[0] == "ATTACK") {
            if (attackingClassHpOverrides.ContainsKey(playerClass)) {
                Debug.Log(string.Format("CHPM: Configuration for {0} class {1} already defined, skipping argument...", classArg[0], classArg[1]));
            } else {
                Debug.Log(string.Format("CHPM: {0} Class {1} default HP will be overridden for {2} HP", classArg[0], classArg[1], hpOverride));
                attackingClassHpOverrides.Add(playerClass, hpOverride);
            }
        } else if (classArg[0] == "DEFEND") {
            if (defendingClassHpOverrides.ContainsKey(playerClass)) {
                Debug.Log(string.Format("CHPM: Configuration for {0} class {1} already defined, skipping argument...", classArg[0], classArg[1]));
            } else {
                Debug.Log(string.Format("CHPM: {0} Class {1} default HP will be overridden for {2} HP", classArg[0], classArg[1], hpOverride));
                defendingClassHpOverrides.Add(playerClass, hpOverride);
            }
        }
    }

    private void overrideClassHp(int playerId, PlayerClass playerClass, FactionCountry playerFaction, int hpOverride) {
        Debug.Log(string.Format("CHPM: Player {0} spawned as class {1} in faction (2), applying HP override of {3}", playerId, playerClass, playerFaction, hpOverride));
        int roundTimeRemaining = (int)timeRemaining - 2;
        var rcSlapCommand = string.Format("delayed {0} serverAdmin slap {1} {2}", roundTimeRemaining, playerId, hpOverride);
        f1MenuInputField.onEndEdit.Invoke(rcSlapCommand);
    }

    public void OnUpdateTimeRemaining(float time) {
        timeRemaining = time;
    }
    public void OnRoundDetails(int roundId, string serverName, string mapName, FactionCountry attackingFaction, FactionCountry defendingFaction, GameplayMode gameplayMode, GameType gameType) {
        // Get which faction is attacking/defending as this information is not passed in onPlayerSpawned
        FACTION_ATTACKING = attackingFaction;
        FACTION_DEFENDING = defendingFaction;
    }

    public void OnSyncValueState(int value) {
    }

    public void OnUpdateSyncedTime(double time) {
    }

    public void OnUpdateElapsedTime(float time) {
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

    public void OnScorableAction(int playerId, int score, ScorableActionType reason) {
    }

    public void OnTextMessage(int playerId, TextChatChannel channel, string text) {
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