namespace apPatcherApp
{
    using System;

    public class settings
    {
        public const string APP_NAME = "DS-Scene Rom Tool";
        public const string APP_VERSION = "1.0 build 1215";
        public const string APP_BUILD = "1.2.1.5";
        public const string WEB_INFO_VERSION = "2";
        public const int HEADER_CACHE_VERSION = 2;
        public const bool HEADER_CACHE_VERSION_ON = true;
        public const int MAX_MEMORY_BATCH_MB = 100;
        public const int BUFFER_SIZE = 0x49928;
        public const string DATA_FILE_FOLDER = "data/";
        public const int DOWNLOAD_CHUNK_SIZE = 0x200;
        public const string APP_URL = "http://files-ds-scene.net/romtool/";
        public const string WEB_INFO_FORUM_URL = "http://www.ds-scene.net/?s=viewtopic&nid=";
        public const string WEB_INFO_URL = "http://www.ds-scene.net/romtool.php?version=2&hash=";
        public const string WEB_INFO_FLAG_URL = "http://www.ds-scene.net/data/images/icons/flags/";
        public const int PATCH_DB_SIZE = 0x1388;
        public const int MAX_PATCH_LINES = 100;
        public const string CMP_FILE_ENCRYPTION_KEY = "3F006F003F003F001000000069003F00";
        public const string DB_ENCRYPTION_KEY = "790077003F0028003F0050003F003F00";
        public const string DB_FILE_EXT = ".dsapdb";
        public const char DB_COLUMN_SEPERATOR = '|';
        public const string PATCH_DB_FILE = "offsets";
        public const string EXTRACT_TEMP_DIR = "/data/temp/";
        public const int MAX_CMP_GAMES = 0x61a8;
        public const int MAX_BATCH_FILES = 0x61a8;
        public const int SINGLE_BATCH_FILE_PROCESSES = 8;
        public const bool SINGLE_BATCH_FILE_PROCESSES_TEST = false;
        public const int SINGLE_ORGANISE_FILE_PROCESSES = 10;
        public const string BATCH_LOG_FN = "log.txt";
        public const string UPDATE_EXTENSION = ".rar";
        public const string UPDATE_CHECK_FILE = "latest_version_build_1200.bin";
        public const string UPDATE_CHANGELOG = "changelog_build_1200.bin";
        public const string UPDATER_EXE = "updater_v0.2.exe";
        public const string OLD_UPDATER_EXE = "updater.exe";
        public const string APP_MAINTAINTER = "www.ds-scene.net";
        public const string AP_DB_MAINTAINER = "RetroGameFan";
        public const string CMP_DB_MAINTAINER = "CMP";
        public const int MAX_CRC_DB_ITEMS = 0x61a8;
        public const int MAX_CRC_DUPES = 50;
        public const int MAX_MAKERS = 0x400;
        public const int REFRESH_RESTRICT_SECS = 60;
        public const int WEB_UPDATE_RESTRICT_HOURS = 0xa8;
        public const int MAX_COLLECTION_DB_ITEMS = 0x61a8;
        public const int MAX_COLLECTION_DBS = 100;
        public const string TO_DO_LIST = "";
    }
}

