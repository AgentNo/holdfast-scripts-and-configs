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
    private Dictionary<PlayerClass, int> classHpOverrides = new Dictionary<PlayerClass, int>();

    public void OnIsServer(bool server) {
        Debug.Log("CHPM: Starting load...");
        //Get all the canvas items in the game
        var canvases = Resources.FindObjectsOfTypeAll<Canvas>();
        for (int i = 0; i < canvases.Length; i++) {
            if (string.Compare(canvases[i].name, "Game Console Panel", true) == 0) {
                //Inside this, now we need to find the input field where the player types messages.
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
                    string[] classArg = splitData[2].Split(',');
                    Debug.Log(string.Format("CHPM: Attempting to parse class HP override for class {0}", classArg[0]));

                    PlayerClass playerClass;
                    if (System.Enum.TryParse<PlayerClass>(classArg[0], out playerClass)) {
                        int hpOverride;
                        Debug.Log("CHPM: Attempting to parse HP override...");
                        if (int.TryParse(classArg[1], out hpOverride)) {
                            if(classHpOverrides.ContainsKey(playerClass)) {
                                Debug.Log(string.Format("CHPM: Configuration for class {0} already defined, skipping argument...", classArg[0]));
                            } else {
                                Debug.Log(string.Format("CHPM: Class {0} default HP will be overridden for {1} HP", classArg[0], hpOverride));
                                classHpOverrides.Add(playerClass, hpOverride);
                            }
                        } else {
                            Debug.Log(string.Format("CHPM: Error parsing HP override for class {0} - ensure it is a valid number!", classArg[0]));
                        }
                    } else {
                        Debug.Log(string.Format("CHPM: Error parsing HP override for class {0} - class enum is not valid", classArg[0]));
                    }
                } else {
                    Debug.Log(string.Format("CHPM: Syntax error parsing variable: '{0}'", splitData[1]));
                }
            }
        }
    }

    public void OnPlayerSpawned(int playerId, int spawnSectionId, FactionCountry playerFaction, PlayerClass playerClass, int uniformId, GameObject playerObject) {
        if (classHpOverrides.ContainsKey(playerClass)) {
            Debug.Log(string.Format("CHPM: Player {0} spawned as class {1}, applying HP override of {2}", playerId, playerClass, classHpOverrides[playerClass]));
            var rcSlapCommand = string.Format("serverAdmin slap {0} {1}", playerId, classHpOverrides[playerClass]);
            f1MenuInputField.onEndEdit.Invoke(rcSlapCommand);
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

    public void OnPlayerJoined(int playerId, ulong steamId, string playerName, string regimentTag, bool isBot) {
    }

    public void OnPlayerLeft(int playerId) {
    }

    public void OnScorableAction(int playerId, int score, ScorableActionType reason) {
    }

    public void OnTextMessage(int playerId, TextChatChannel channel, string text) {
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