using UnityEngine;
using System.Collections;


namespace CC.Module.Menu
{
	public class MenuType
	{
		public static int None = 0;
		// Game Enter
		//--------------------------
		public static int DebugLog = 1;
		public static int Login = 2;
		public static int ServerList = 3;
		public static int CreateRole = 4;
		// Game Setting
		public static int Setting = 8;
		// Game Exit
		public static int Exit = 9;
		
		
		// Main UI
		//---------------------------
		public static int MainScene = 10;
		public static int MainUI = 11;
		public static int MsgScroll=12;
		public static int MsgAlert=13;
		public static int Tooltip=14;
		public static int RunCircle=15;

		
		public static int Home=20;
		
		// communication module
		//----------------------------
		public static int Chat = 31;
		public static int MailPanel=32;
		
		// item module
		//----------------------------
		public static int ItemPack=40;
		public static int Equipment=41;
		
		// hero module
		//------------------------------
		public static int Hero = 50;
		
		// soldier module
		//-------------------------------
		public static int Soldier = 60;
		
		// matcher module
		//-------------------------------
		public static int Mathcer = 90;
        public static int Arena = 92;
        public static int Expedition = 93;
		// dungeon module
		//--------------------------------
		public static int Dungeon = 100;
		public static int DungeonPrepare = 101;
		
		// battle module
		public static int WarScene = 110;
		public static int WarUI = 111;
        public static int BattleEnd = 120;
        public static int BattleArrange = 121;
	}
}
