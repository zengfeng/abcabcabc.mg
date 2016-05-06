require "logic/Core/define"
require "logic/Core/functions"
require "logic/Core/GlobalConst"
require "logic/Core/PlayerPrefsKey"
require "logic/Core/Lang"
require "logic/Core/MainManager"
require "logic/Core/EventManager"
require "logic/Core/Event"
require "logic/Core/GuideType"
require "logic/Core/GuideManager"
require "logic/Core/BattleParam"
require "logic/Core/BattleManager"
require "logic/Core/CenterManager"

require "logic/Module/MenuType"
require "logic/Module/MenuPreloadFile"
require "logic/Module/Enter/PreloadFiles"
require "logic/Module/Enter/PreinstanceMenu"

-----------------------
--  Util
-----------------------
require "logic/Util/StringUtil"
require "logic/Util/TimeUtil"
require "logic/Util/print_table"
require "logic/Util/UIUtils"
require "logic/Util/ProtoUtil"
require "logic/Util/DebugUtil"
require "logic/Util/Tween"

-----------------------
--  Config
-----------------------
require "logic/Config/Struct/Pair"
require "logic/Config/Struct/PairList"
require "logic/Config/Struct/PropId"
require "logic/Config/Struct/Prop"
require "logic/Config/Struct/PropList"
require "logic/Config/ConfigModel"
require "logic/Config/PropConfig"
require "logic/Config/AvatarConfig"
require "logic/Config/BoxConfig"
require "logic/Config/CardConfig"
require "logic/Config/CardLevelConfig"
require "logic/Config/ChestConfig"
require "logic/Config/ChestTypeConfig"
require "logic/Config/ExpConfig"
require "logic/Config/GradeConfig"
require "logic/Config/SkillDisplayConfig"
require "logic/Config/TaskConfig"
require "logic/Config/RobotConfig"
require "logic/Config/RobotFloatPropConfig"
require "logic/Config/TrainConfig"
require "logic/Config/RoleNameConfig"
require "logic/Config/TipConfig"
require "logic/Config/MailConfig"
require "logic/Config/SignConfig"
require "logic/Config/SoldierConfig"
require "logic/Config/DungeonConfig"
require "logic/Config/DungeonStageConfig"
require "logic/Config/ConfigManager"


-----------------------
--  Role
-----------------------
require "logic/Role/User"
require "logic/Role/Role"
require "logic/Role/RoleCard"
require "logic/Role/RoleShopItem"
require "logic/Role/RoleTask"
require "logic/Role/RoleSoldierManager"
require "logic/Role/RoleCardManager"
require "logic/Role/RoleChestManager"
require "logic/Role/RoleShopManager"
require "logic/Role/RoleTaskManager"
require "logic/Role/RoleDungeonManager"
require "logic/Role/User"


-----------------------
--  Proto
-----------------------
require "3rd/pblua/retcode_pb"
require "3rd/pblua/login_pb"
require "3rd/pblua/hall_pb"
require "3rd/pblua/chest_pb"
require "3rd/pblua/mail_pb"
require "3rd/pblua/card_pb"
require "3rd/pblua/rank_pb"
require "3rd/pblua/shop_pb"
require "3rd/pblua/soldier_pb"
require "3rd/pblua/task_pb"
require "3rd/pblua/battle_pb"
require "3rd/pblua/video_pb"
require "3rd/pblua/sign_pb"
require "3rd/pblua/league_pb"
require "3rd/pblua/dungeon_pb"
require "logic/Proto/LoginProto"
require "logic/Proto/EnterProto"
require "logic/Proto/ChestProto"
require "logic/Proto/CardProto"
require "logic/Proto/NotifyProto"
require "logic/Proto/ShopProto"
require "logic/Proto/ArenaProto"
require "logic/Proto/TaskProto"
require "logic/Proto/RankProto"
require "logic/Proto/MailProto"
require "logic/Proto/SoldierProto"
require "logic/Proto/VideoProto"
require "logic/Proto/SignProto"
require "logic/Proto/LeagueProto"
require "logic/Proto/DungeonProto"

-----------------------
--  Module
-----------------------

--Common
require "logic/Module/Common/ChestIcon"
require "logic/Module/Common/BaseWindow"
require "logic/Module/Common/MsgWindow"
require "logic/Module/Common/ChestWindow"
require "logic/Module/Common/GradeIcon"
require "logic/Module/Common/ItemCard"
require "logic/Module/Common/CardBrand"
require "logic/Module/Common/Util/CommonUtil"
require "logic/Module/Common/ItemConst"
require "logic/Module/Common/RoleLevelPanel"
require "logic/Module/Common/GradekUpPanel"
require "logic/Module/Common/GradeCard"
require "logic/Module/Common/ChangeNameWin"
require "logic/Module/Common/SettingWindow"

--Enter
require "logic/Module/Enter/LoginPanel"
require "logic/Module/Enter/ServerListPanel"

--Main
require "logic/Module/Main/ChestBoard"
require "logic/Module/Main/MainPanel"
require "logic/Module/Home/HomePanel"

--Recruit
require "logic/Module/Recruit/RecruitChest"
require "logic/Module/Recruit/RecruitPanel"

--OpenChest
require "logic/Module/OpenChest/OpenChestParam"
require "logic/Module/OpenChest/OpenChestPanel"

--Embattle
require "logic/Module/Embattle/EmbattleCard"
require "logic/Module/Embattle/EmbattlePanel"

--Embattle
require "logic/Module/CardInfo/CardLevelupInfo"
require "logic/Module/CardInfo/CardInfoPanel"

--Shop
require "logic/Module/Shop/ShopItem"
require "logic/Module/Shop/ShopBuyWindow"
require "logic/Module/Shop/ShopPanel"

--Rank
require "logic/Module/Rank/RankItem"
require "logic/Module/Rank/RankPanel"

--Matcher
require "logic/Module/Matcher/MatcherPanel"

--PVPLoadingPanel
require "logic/Module/LoadingScene/PVPLoadingPanel"

--BattleEndPanel
require "logic/Module/BattleEnd/FightResultItem"
require "logic/Module/BattleEnd/BattleEndPanel"

--TaskPanel
require "logic/Module/Task/TaskItem"
require "logic/Module/Task/TaskPanel"
require "logic/Module/Task/MailItem"
require "logic/Module/Task/FightItem"
require "logic/Module/Task/SignItem"

--SoldierPanel
require "logic/Module/Soldier/SoldierBuyWin"
require "logic/Module/Soldier/SoldierShopItem"
require "logic/Module/Soldier/SoldierPanel"

--Dungeon
require "logic/Module/Dungeon/DungeonSelect"
require "logic/Module/Dungeon/DungeonInfo"
require "logic/Module/Dungeon/DungeonPanel"

--VideoPanel
require "logic/Module/Video/VideoPanel"
require "logic/Module/Video/VideoItem"

--league
require "logic/Module/League/LeaguePanel"
require "logic/Module/League/LeagueItem"
require "logic/Module/League/LeagueInfoPanel"
require "logic/Module/League/MemberItem"
require "logic/Module/League/LeagueCreate"