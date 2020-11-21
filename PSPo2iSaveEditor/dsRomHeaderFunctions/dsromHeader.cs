namespace dsRomHeaderFunctions
{
    using apPatcherApp;
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows.Forms;

    public class dsromHeader
    {
        private Country[] countries = new Country[30];
        public int countriesFilled;
        public Maker[] makers = new Maker[0x400];
        public int makersFilled;
        private runFunctionsType run = new runFunctionsType();
        public romHeader_HeaderClass romHeader = new romHeader_HeaderClass();

        public void addCountry(string code, string name)
        {
            int num;
            this.countriesFilled = (num = this.countriesFilled) + 1;
            if (num < 30)
            {
                this.countries[this.countriesFilled] = new Country();
                this.countries[this.countriesFilled].code = code;
                this.countries[this.countriesFilled].name = name;
            }
        }

        public void addMaker(string code, string name)
        {
            int num;
            this.makersFilled = (num = this.makersFilled) + 1;
            if (num < 0x400)
            {
                this.makers[this.makersFilled] = new Maker();
                this.makers[this.makersFilled].code = code;
                this.makers[this.makersFilled].name = name;
            }
        }

        public string countryNameFromCode(string code)
        {
            for (int i = 0; i < 30; i++)
            {
                if ((this.countries[i] != null) && ((code != "") && (this.countries[i].code.ToUpper() == code.ToUpper())))
                {
                    return this.countries[i].name;
                }
            }
            return "???";
        }

        public bool CreateIcon()
        {
            this.romHeader.iconHasTrans = false;
            this.romHeader.icon.gfx = new Bitmap(0x20, 0x20);
            int num = 0;
            while (num < 4)
            {
                int num2 = 0;
                while (true)
                {
                    if (num2 >= 4)
                    {
                        num++;
                        break;
                    }
                    int num3 = 0;
                    while (true)
                    {
                        if (num3 >= 8)
                        {
                            num2++;
                            break;
                        }
                        int num4 = 0;
                        while (true)
                        {
                            if (num4 >= 8)
                            {
                                num3++;
                                break;
                            }
                            int num5 = num2 + (num * 4);
                            int index = this.romHeader.icon.tiles[((num5 * 0x40) + (num4 * 8)) + num3];
                            if (this.romHeader.icon.pal[index] == null)
                            {
                                return false;
                            }
                            int num7 = int.Parse(this.run.hexAndMathFunction.reversehex(this.romHeader.icon.pal[index], 4), NumberStyles.HexNumber);
                            int red = 0;
                            this.romHeader.iconHasTrans = true;
                            if (Program.form.getPalCheckBox(index).Checked)
                            {
                                red = (num7 % 0x20) * 8;
                                this.romHeader.icon.gfx.SetPixel((num2 * 8) + num3, (num * 8) + num4, Color.FromArgb(0, red, ((num7 / 0x20) % 0x20) * 8, ((num7 / 0x400) % 0x20) * 8));
                            }
                            else
                            {
                                red = (num7 % 0x20) * 8;
                                this.romHeader.icon.gfx.SetPixel((num2 * 8) + num3, (num * 8) + num4, Color.FromArgb(red, ((num7 / 0x20) % 0x20) * 8, ((num7 / 0x400) % 0x20) * 8));
                            }
                            num4++;
                        }
                    }
                }
            }
            return true;
        }

        public void deleteHeaderCacheFile(string hash)
        {
            if (hash != "")
            {
                string[] strArray = new string[] { "data/header_cache/", hash.Substring(0, 1), "/", hash, ".dsrhd" };
                string path = string.Concat(strArray);
                bool flag = false;
                if (!System.IO.File.Exists(path))
                {
                    flag = true;
                }
                while (!flag)
                {
                    try
                    {
                        System.IO.File.Delete(path);
                        flag = true;
                    }
                    catch
                    {
                        flag = false;
                        Application.DoEvents();
                    }
                }
            }
        }

        private void failedLoad(string code, bool batch)
        {
            if (!batch)
            {
                MessageBox.Show("Failed parsing the rom header [0x" + code + "]");
            }
        }

        public void initCountries()
        {
            if (this.countries == null)
            {
                this.countries = new Country[30];
            }
            this.countriesFilled = 0;
            this.addCountry("A", "RFREE");
            this.addCountry("C", "CHI");
            this.addCountry("D", "NOE");
            this.addCountry("E", "USA");
            this.addCountry("F", "NOE");
            this.addCountry("H", "HOL");
            this.addCountry("I", "ITA");
            this.addCountry("J", "JPN");
            this.addCountry("K", "KOR");
            this.addCountry("O", "EUSA?");
            this.addCountry("P", "EUR");
            this.addCountry("S", "SPA");
            this.addCountry("U", "AUS");
            this.addCountry("V", "EUR");
            this.addCountry("X", "EUU");
        }

        public void initMakers()
        {
            if (this.makers == null)
            {
                this.makers = new Maker[0x400];
            }
            this.makersFilled = 0;
            this.addMaker("01", "Nintendo");
            this.addMaker("02", "Rocket Games, Ajinomoto");
            this.addMaker("03", "Imagineer-Zoom");
            this.addMaker("04", "Gray Matter?");
            this.addMaker("05", "Zamuse");
            this.addMaker("06", "Falcom");
            this.addMaker("07", "Enix?");
            this.addMaker("08", "Capcom");
            this.addMaker("09", "Hot B Co.");
            this.addMaker("0A", "Jaleco");
            this.addMaker("0B", "Coconuts Japan");
            this.addMaker("0C", "Coconuts Japan/G.X.Media");
            this.addMaker("0D", "Micronet?");
            this.addMaker("0E", "Technos");
            this.addMaker("0F", "Mebio Software");
            this.addMaker("0G", "Shouei System");
            this.addMaker("0H", "Starfish");
            this.addMaker("0J", "Mitsui Fudosan/Dentsu");
            this.addMaker("0K", "SHINGAKUSHA/ZENKAKEN");
            this.addMaker("0L", "Warashi Inc.");
            this.addMaker("0N", "Nowpro");
            this.addMaker("0P", "Game Village");
            this.addMaker("0Q", "IE Institute");
            this.addMaker("10", "?????????????");
            this.addMaker("12", "Infocom");
            this.addMaker("13", "Electronic Arts Japan");
            this.addMaker("15", "Cobra Team");
            this.addMaker("16", "Human/Field");
            this.addMaker("17", "KOEI");
            this.addMaker("18", "Hudson Soft");
            this.addMaker("19", "S.C.P.");
            this.addMaker("1A", "Yanoman");
            this.addMaker("1C", "Tecmo Products");
            this.addMaker("1D", "Japan Glary Business");
            this.addMaker("1E", "Forum/OpenSystem");
            this.addMaker("1F", "Virgin Games");
            this.addMaker("1G", "SMDE");
            this.addMaker("1J", "Daikokudenki");
            this.addMaker("1P", "Creatures Inc.");
            this.addMaker("1Q", "TDK Deep Impresion");
            this.addMaker("20", "Destination Software, KSS");
            this.addMaker("21", "Sunsoft/Tokai Engineering??");
            this.addMaker("22", "POW, VR 1 Japan??");
            this.addMaker("23", "Micro World");
            this.addMaker("25", "San-X");
            this.addMaker("26", "Enix");
            this.addMaker("27", "Loriciel/Electro Brain");
            this.addMaker("28", "Kemco Japan");
            this.addMaker("29", "Seta");
            this.addMaker("2A", "Culture Brain");
            this.addMaker("2C", "Palsoft");
            this.addMaker("2D", "Visit Co.,Ltd.");
            this.addMaker("2E", "Intec");
            this.addMaker("2F", "System Sacom");
            this.addMaker("2G", "Poppo");
            this.addMaker("2H", "Ubisoft Japan");
            this.addMaker("2J", "Media Works");
            this.addMaker("2K", "NEC InterChannel");
            this.addMaker("2L", "Tam");
            this.addMaker("2M", "Jordan");
            this.addMaker("2N", "Smilesoft ???, Rocket ???");
            this.addMaker("2Q", "Mediakite");
            this.addMaker("30", "Viacom");
            this.addMaker("31", "Carrozzeria");
            this.addMaker("32", "Dynamic");
            this.addMaker("34", "Magifact");
            this.addMaker("35", "Hect");
            this.addMaker("36", "Codemasters");
            this.addMaker("37", "Taito/GAGA Communications");
            this.addMaker("38", "Laguna");
            this.addMaker("39", "Telstar Fun & Games, Event/Taito");
            this.addMaker("3B", "Arcade Zone Ltd");
            this.addMaker("3C", "Entertainment International/Empire Software?");
            this.addMaker("3D", "Loriciel");
            this.addMaker("3E", "Gremlin Graphics");
            this.addMaker("3F", "K.Amusement Leasing Co.");
            this.addMaker("40", "Seika Corp.");
            this.addMaker("41", "Ubisoft");
            this.addMaker("42", "Sunsoft US?");
            this.addMaker("44", "Life Fitness");
            this.addMaker("46", "System 3");
            this.addMaker("47", "Spectrum Holobyte");
            this.addMaker("49", "IREM");
            this.addMaker("4A", "Gakken");
            this.addMaker("4B", "Raya Systems");
            this.addMaker("4C", "Renovation Products");
            this.addMaker("4D", "Malibu Games");
            this.addMaker("4F", "Eidos (was U.S. Gold <=1995)");
            this.addMaker("4G", "Playmates Interactive?");
            this.addMaker("4J", "Fox Interactive");
            this.addMaker("4K", "Time Warner Interactive");
            this.addMaker("4Q", "Disney Interactive");
            this.addMaker("4S", "Black Pearl");
            this.addMaker("4U", "Advanced Productions");
            this.addMaker("4X", "GT Interactive");
            this.addMaker("4Y", "RARE?");
            this.addMaker("4Z", "Crave Entertainment");
            this.addMaker("50", "Absolute Entertainment");
            this.addMaker("51", "Acclaim");
            this.addMaker("52", "Activision");
            this.addMaker("53", "American Sammy");
            this.addMaker("54", "ROCKSTAR GAMES™, Take 2 Interactive (before it was GameTek)");
            this.addMaker("55", "Hi Tech");
            this.addMaker("56", "LJN LTD.");
            this.addMaker("58", "Mattel");
            this.addMaker("5A", "Mindscape, Red Orb Entertainment?");
            this.addMaker("5B", "Romstar");
            this.addMaker("5C", "Taxan");
            this.addMaker("5D", "Midway (before it was Tradewest)");
            this.addMaker("5F", "American Softworks");
            this.addMaker("5G", "Majesco Entertainment");
            this.addMaker("5H", "3DO");
            this.addMaker("5K", "Hasbro");
            this.addMaker("5L", "NewKidCo");
            this.addMaker("5M", "Telegames");
            this.addMaker("5N", "Metro3D");
            this.addMaker("5P", "Vatical Entertainment");
            this.addMaker("5Q", "LEGO Media");
            this.addMaker("5S", "Xicat Interactive");
            this.addMaker("5T", "Cryo Interactive");
            this.addMaker("5W", "Red Storm Entertainment");
            this.addMaker("5X", "Microids");
            this.addMaker("5Z", "Conspiracy/Swing");
            this.addMaker("60", "Titus");
            this.addMaker("61", "Virgin Interactive");
            this.addMaker("62", "Maxis");
            this.addMaker("64", "LucasArts Entertainment");
            this.addMaker("67", "Ocean");
            this.addMaker("68", "Bethesda/ZeniMax Europe Ltd.");
            this.addMaker("69", "Electronic Arts");
            this.addMaker("6B", "Laser Beam");
            this.addMaker("6E", "Elite Systems");
            this.addMaker("6F", "Electro Brain");
            this.addMaker("6G", "The Learning Company");
            this.addMaker("6H", "BBC");
            this.addMaker("6J", "Software 2000");
            this.addMaker("6K", "UFO Interactive Games Inc.");
            this.addMaker("6L", "BAM! Entertainment");
            this.addMaker("6M", "Studio 3");
            this.addMaker("6N", "Midas Interactive");
            this.addMaker("6Q", "Classified Games");
            this.addMaker("6S", "TDK Mediactive");
            this.addMaker("6U", "DreamCatcher");
            this.addMaker("6V", "JoWood Produtions");
            this.addMaker("6W", "SEGA");
            this.addMaker("6X", "Wannado Edition");
            this.addMaker("6Y", "LSP");
            this.addMaker("6Z", "ITE Media");
            this.addMaker("70", "Infogrames");
            this.addMaker("71", "Interplay");
            this.addMaker("72", "JVC");
            this.addMaker("73", "Parker Brothers");
            this.addMaker("75", "Sales Curve");
            this.addMaker("78", "THQ");
            this.addMaker("79", "Accolade");
            this.addMaker("7A", "Triffix Entertainment");
            this.addMaker("7C", "Microprose Software");
            this.addMaker("7D", "Universal Interactive, Sierra, Simon & Schuster?");
            this.addMaker("7F", "Kemco");
            this.addMaker("7G", "Rage Software");
            this.addMaker("7H", "Encore");
            this.addMaker("7J", "Zoo");
            this.addMaker("7K", "BVM, Kiddinx");
            this.addMaker("7L", "Simon & Schuster Interactive");
            this.addMaker("7M", "Asmik Ace Entertainment Inc./AIA");
            this.addMaker("7N", "Empire Interactive?");
            this.addMaker("7Q", "Jester Interactive");
            this.addMaker("7T", "Scholastic");
            this.addMaker("7U", "Ignition Entertainment");
            this.addMaker("7V", "Summitsoft");
            this.addMaker("7W", "Stadlbauer");
            this.addMaker("80", "Misawa");
            this.addMaker("81", "Teichiku");
            this.addMaker("82", "Namco Ltd.");
            this.addMaker("83", "LOZC");
            this.addMaker("84", "KOEI");
            this.addMaker("86", "Tokuma Shoten Intermedia");
            this.addMaker("87", "Tsukuda Original");
            this.addMaker("88", "DATAM-Polystar");
            this.addMaker("8B", "Bulletproof Software");
            this.addMaker("8C", "Vic Tokai Inc.");
            this.addMaker("8E", "Character Soft");
            this.addMaker("8F", "I'Max");
            this.addMaker("8G", "Saurus");
            this.addMaker("8J", "General Entertainment");
            this.addMaker("8M", "CYBERFRONT");
            this.addMaker("8N", "Success");
            this.addMaker("8P", "SEGA Japan");
            this.addMaker("90", "Takara Amusement");
            this.addMaker("91", "Chun Soft");
            this.addMaker("92", "Video System, McO'River???");
            this.addMaker("93", "BEC");
            this.addMaker("95", "Varie");
            this.addMaker("96", "Yonezawa/S'pal");
            this.addMaker("97", "Kaneko");
            this.addMaker("99", "Marvelous Interactive Inc., Rising Star (previously Victor Interactive Software, Pack in Video)");
            this.addMaker("9A", "Nichibutsu/Nihon Bussan");
            this.addMaker("9B", "Tecmo");
            this.addMaker("9C", "Imagineer");
            this.addMaker("9F", "Nova");
            this.addMaker("9G", "Den'Z");
            this.addMaker("9H", "Bottom Up");
            this.addMaker("9J", "TGL");
            this.addMaker("9L", "Hasbro Japan?");
            this.addMaker("9N", "Marvelous Entertainment");
            this.addMaker("9P", "Keynet Inc.");
            this.addMaker("9Q", "Hands-On Entertainment");
            this.addMaker("A0", "Telenet");
            this.addMaker("A1", "Hori");
            this.addMaker("A4", "Konami Digital Entertainment");
            this.addMaker("A5", "K.Amusement Leasing Co.");
            this.addMaker("A6", "Kawada");
            this.addMaker("A7", "Takara");
            this.addMaker("A9", "Technos Japan Corp.");
            this.addMaker("AA", "JVC, Victor Musical Indutries");
            this.addMaker("AC", "Toei Animation");
            this.addMaker("AD", "Toho");
            this.addMaker("AF", "Namco");
            this.addMaker("AG", "Media Rings Corporation");
            this.addMaker("AH", "J-Wing");
            this.addMaker("AJ", "Pioneer LDC");
            this.addMaker("AK", "KID");
            this.addMaker("AL", "Mediafactory");
            this.addMaker("AP", "Infogrames Hudson");
            this.addMaker("AQ", "Kiratto. Ludic Inc");
            this.addMaker("AR", "ARIKA");
            this.addMaker("B0", "Acclaim Japan");
            this.addMaker("B1", "ASCII (was Nexoft?)");
            this.addMaker("B2", "Bandai");
            this.addMaker("B4", "Enix");
            this.addMaker("B6", "HAL Laboratory");
            this.addMaker("B7", "SNK");
            this.addMaker("B9", "Pony Canyon");
            this.addMaker("BA", "Culture Brain");
            this.addMaker("BB", "Sunsoft");
            this.addMaker("BC", "Toshiba EMI");
            this.addMaker("BD", "Sony Imagesoft");
            this.addMaker("BF", "Sammy");
            this.addMaker("BG", "Magical");
            this.addMaker("BH", "Visco");
            this.addMaker("BJ", "Compile ");
            this.addMaker("BL", "MTO Inc.");
            this.addMaker("BN", "Sunrise Interactive");
            this.addMaker("BP", "Global A Entertainment");
            this.addMaker("BQ", "Fuuki");
            this.addMaker("C0", "Taito");
            this.addMaker("C2", "Kemco");
            this.addMaker("C3", "Square");
            this.addMaker("C4", "Tokuma Shoten");
            this.addMaker("C5", "Data East");
            this.addMaker("C6", "Tonkin House\t(was Tokyo Shoseki)");
            this.addMaker("C8", "Koei");
            this.addMaker("CA", "Konami/Ultra/Palcom");
            this.addMaker("CB", "NTVIC/VAP");
            this.addMaker("CC", "Use Co.,Ltd.");
            this.addMaker("CD", "Meldac");
            this.addMaker("CE", "Pony Canyon");
            this.addMaker("CF", "Angel, Sotsu Agency/Sunrise");
            this.addMaker("CJ", "Boss");
            this.addMaker("CG", "Yumedia/Aroma Co., Ltd");
            this.addMaker("CK", "Axela/Crea-Tech?");
            this.addMaker("CL", "Sekaibunka-Sha, Sumire kobo?, Marigul Management Inc.?");
            this.addMaker("CM", "Konami Computer Entertainment Osaka");
            this.addMaker("CP", "Enterbrain");
            this.addMaker("CQ", "FromSoftware/3 O'Clock");
            this.addMaker("D0", "Taito/Disco");
            this.addMaker("D1", "Sofel");
            this.addMaker("D2", "Quest, Bothtec");
            this.addMaker("D3", "Sigma, ?????");
            this.addMaker("D4", "Ask Kodansha");
            this.addMaker("D6", "Naxat");
            this.addMaker("D7", "Copya System");
            this.addMaker("D8", "Capcom Co., Ltd.");
            this.addMaker("D9", "Banpresto");
            this.addMaker("DA", "Takara TOMY");
            this.addMaker("DB", "LJN Japan");
            this.addMaker("DD", "NCS");
            this.addMaker("DE", "Human Entertainment");
            this.addMaker("DF", "Altron");
            this.addMaker("DG", "Jaleco???");
            this.addMaker("DH", "Gaps Inc.");
            this.addMaker("DJ", "Shogakukan");
            this.addMaker("DL", "Digital Kids");
            this.addMaker("DN", "Elf");
            this.addMaker("DQ", "IDEA FACTORY, Compile Heart");
            this.addMaker("E0", "Jaleco");
            this.addMaker("E1", "????");
            this.addMaker("E2", "Yutaka");
            this.addMaker("E3", "Varie");
            this.addMaker("E4", "T&ESoft");
            this.addMaker("E5", "Epoch");
            this.addMaker("E7", "Athena");
            this.addMaker("E8", "Asmik");
            this.addMaker("E9", "Natsume Inc.");
            this.addMaker("EA", "King Records");
            this.addMaker("EB", "Atlus");
            this.addMaker("EC", "Epic/Sony Records");
            this.addMaker("EE", "IGS");
            this.addMaker("EG", "Chatnoir");
            this.addMaker("EH", "Right Stuff");
            this.addMaker("EJ", "????");
            this.addMaker("EL", "Spike");
            this.addMaker("EM", "Konami Computer Entertainment Tokyo");
            this.addMaker("EN", "Alphadream Corporation");
            this.addMaker("EP", "Sting");
            this.addMaker("ES", "Starfish-SD");
            this.addMaker("F0", "A Wave");
            this.addMaker("F1", "Motown Software");
            this.addMaker("F2", "Left Field Entertainment");
            this.addMaker("F3", "Extreme Ent. Grp.");
            this.addMaker("F4", "TecMagik");
            this.addMaker("F9", "Cybersoft");
            this.addMaker("FB", "Psygnosis");
            this.addMaker("FE", "Davidson/Western Tech.");
            this.addMaker("FH", "Foreign Media Games");
            this.addMaker("FJ", "Virtual Toys");
            this.addMaker("FK", "The Game Factory (Europe)");
            this.addMaker("FM", "Aspyr");
            this.addMaker("FP", "Mastiff");
            this.addMaker("FR", "dtp entertainment AG");
            this.addMaker("FS", "XS Games");
            this.addMaker("FT", "Daiwon");
            this.addMaker("FX", "Red Mile Entertainment");
            this.addMaker("G0", "ALPHA-UNIT");
            this.addMaker("G2", "Yuke's");
            this.addMaker("G1", "PCCW Japan");
            this.addMaker("G4", "KiKi Co Ltd");
            this.addMaker("G5", "Open Sesame Inc???");
            this.addMaker("G6", "Sims");
            this.addMaker("G7", "Broccoli");
            this.addMaker("G8", "Avex");
            this.addMaker("G9", "D3 Publisher");
            this.addMaker("GB", "Konami Computer Entertainment Japan");
            this.addMaker("GD", "Square-Enix");
            this.addMaker("GE", "Kids Station");
            this.addMaker("GG", "O3 Entertainment");
            this.addMaker("GK", "Genki");
            this.addMaker("GL", "Gameloft");
            this.addMaker("GM", "Gamecock Media Group/Renegade Kid LLC");
            this.addMaker("GN", "Oxygen Games");
            this.addMaker("GP", "D3DB, S.r.l.");
            this.addMaker("GQ", "Games Factory Online Engine Software");
            this.addMaker("GR", "Emme Interactive/Avanquest software");
            this.addMaker("GT", "505 Games");
            this.addMaker("GW", "Mercury Games");
            this.addMaker("GY", "The Game Factory (USA)");
            this.addMaker("GZ", "Unknown");
            this.addMaker("H2", "Aruze");
            this.addMaker("H3", "Ertain");
            this.addMaker("H4", "SNK Playmore");
            this.addMaker("H6", "MYCOM");
            this.addMaker("H8", "ASNetworks");
            this.addMaker("HA", "Dorasu/Dorart");
            this.addMaker("HB", "Denyusha");
            this.addMaker("HC", "Plato");
            this.addMaker("HD", "Oaks(Pi Arts)/Princess-soft");
            this.addMaker("HE", "Gust");
            this.addMaker("HF", "Level5");
            this.addMaker("HG", "Graffiti Entertainment");
            this.addMaker("HH", "Focus Home Interactive");
            this.addMaker("HJ", "Unknown");
            this.addMaker("HM", "HMH Interactive");
            this.addMaker("HS", "Unknown");
            this.addMaker("HV", "BHV Software");
            this.addMaker("HZ", "Unknown");
            this.addMaker("IH", "Yojigen");
            this.addMaker("J0", "Four Winds");
            this.addMaker("J1", "Noise Factory");
            this.addMaker("J2", "Benesse Corporation");
            this.addMaker("J3", "Paon");
            this.addMaker("J4", "Gakken Index");
            this.addMaker("J6", "Kokuyo");
            this.addMaker("J7", "Digital Works");
            this.addMaker("J9", "AQ Interactive");
            this.addMaker("JA", "Skip");
            this.addMaker("JB", "GungHo Games");
            this.addMaker("JC", "Red Entertainment");
            this.addMaker("JD", "SKONEC");
            this.addMaker("JE", "e frontier");
            this.addMaker("JF", "ARC SYSTEM WORKS");
            this.addMaker("JG", "Unknown");
            this.addMaker("JH", "Unknown");
            this.addMaker("JJ", "Deep Silver, Inc");
            this.addMaker("JM", "Interactive Brains");
            this.addMaker("JN", "Unknown");
            this.addMaker("JQ", "Unknown");
            this.addMaker("JW", "Unknown");
            this.addMaker("JZ", "Unknown");
            this.addMaker("L9", "Genterprise");
            this.addMaker("K0", "Comolink");
            this.addMaker("K1", "Educational Network");
            this.addMaker("K3", "Yudo");
            this.addMaker("K4", "Unknown");
            this.addMaker("K5", "MegaHouse");
            this.addMaker("K7", "Sonic Powered");
            this.addMaker("K8", "GungHo Works");
            this.addMaker("K9", "fonfun");
            this.addMaker("KA", "Alchemist");
            this.addMaker("KB", "Nippon Ichi Software");
            this.addMaker("KC", "CAVE");
            this.addMaker("KD", "DigiToys Inc.");
            this.addMaker("KE", "Unknown");
            this.addMaker("KF", "Mirai Shounen");
            this.addMaker("KG", "Kando Games");
            this.addMaker("KJ", "Unknown");
            this.addMaker("KM", "Europress/Deep Silver/fantastic.tv");
            this.addMaker("KP", "Unknown");
            this.addMaker("KR", "Krea Medie");
            this.addMaker("KS", "Unknown");
            this.addMaker("KX", "RomeR MODIFIED!");
            this.addMaker("L0", "Unknown");
            this.addMaker("L1", "Zenrin");
            this.addMaker("L2", "Unknown");
            this.addMaker("L4", "Unknown");
            this.addMaker("L5", "Digital Media Lab.");
            this.addMaker("L9", "5pb./Genterprise");
            this.addMaker("LA", "Unknown");
            this.addMaker("LB", "Unknown");
            this.addMaker("LE", "Unknown");
            this.addMaker("LG", "Lago Srl");
            this.addMaker("LQ", "Unknown");
            this.addMaker("LR", "Unknown");
            this.addMaker("LS", "Unknown");
            this.addMaker("LT", "Unknown");
            this.addMaker("LX", "Lexicon Entertainment");
            this.addMaker("M3", "Unknown");
            this.addMaker("M5", "media5");
            this.addMaker("M7", "Unknown");
            this.addMaker("M8", "Unknown");
            this.addMaker("M9", "Unknown");
            this.addMaker("MA", "Unknown");
            this.addMaker("MG", "Megacyber");
            this.addMaker("MH", "Unknown");
            this.addMaker("MJ", "MumboJumbo");
            this.addMaker("MK", "Monte Cristo");
            this.addMaker("ML", "dtp young entertainment");
            this.addMaker("MN", "Mindscape Northern Europe B.V");
            this.addMaker("MP", "Dimple Entertainment");
            this.addMaker("MQ", "Micro Application");
            this.addMaker("MR", "Mindscape");
            this.addMaker("MS", "MileStone Inc.");
            this.addMaker("MT", "blast!/Blast Entertainment Limited");
            this.addMaker("MV", "Rising Star Games");
            this.addMaker("N0", "LukPlus");
            this.addMaker("N5", "Unknown");
            this.addMaker("N8", "Unknown");
            this.addMaker("NC", "Unknown");
            this.addMaker("NJ", "Unknown");
            this.addMaker("NK", "Diffusion, Neko Entertainment");
            this.addMaker("NL", "Unknown");
            this.addMaker("NP", "Nobilis Publishing");
            this.addMaker("NQ", "Unknown");
            this.addMaker("NR", "Destineer");
            this.addMaker("NS", "NIS America, Inc.");
            this.addMaker("NX", "Unknown");
            this.addMaker("NZ", "Unknown");
            this.addMaker("P0", "Unknown");
            this.addMaker("PA", "Unknown");
            this.addMaker("PC", "Unknown");
            this.addMaker("PE", "ALVION");
            this.addMaker("PG", "Unknown");
            this.addMaker("PL", "Playlogic/Engine Software");
            this.addMaker("PN", "Unknown");
            this.addMaker("PP", "Phenomedia");
            this.addMaker("PQ", "PopCap Games, Inc.");
            this.addMaker("PR", "Unknown");
            this.addMaker("PU", "Unknown");
            this.addMaker("PV", "Unknown");
            this.addMaker("PZ", "Unknown");
            this.addMaker("Q2", "Unknown");
            this.addMaker("Q7", "Unknown");
            this.addMaker("Q9", "Unknown");
            this.addMaker("QC", "KADOKAWA GAMES");
            this.addMaker("QH", "Unknown");
            this.addMaker("R7", "Unknown");
            this.addMaker("RB", "DETUNE Ltd.");
            this.addMaker("RM", "cerasus.media GmbH, astragon Software GmbH");
            this.addMaker("RR", "Unknown");
            this.addMaker("S5", "SOUTHPEAK GAMES");
            this.addMaker("WR", "WB Games, Inc.");
            this.addMaker("RS", "Brash Entertainment");
            this.addMaker("RT", "RTL Games");
            this.addMaker("RU", "Unknown");
            this.addMaker("RV", "Unknown");
            this.addMaker("RW", "Unknown");
            this.addMaker("S5", "SouthPeak Interactive");
            this.addMaker("SL", "Tragnarion Studios");
            this.addMaker("SM", "Sony BMG Music");
            this.addMaker("SS", "Unknown");
            this.addMaker("SU", "Unknown");
            this.addMaker("SV", "SevenOne Intermedia");
            this.addMaker("SZ", "Unknown");
            this.addMaker("TK", "Tasuke Works");
            this.addMaker("TM", "Oetinger Interactive");
            this.addMaker("TN", "10Tacle Studios AG.");
            this.addMaker("TP", "Transposia");
            this.addMaker("TR", "Unknown");
            this.addMaker("TV", "Tivola");
            this.addMaker("UH", "Intenium");
            this.addMaker("UJ", "Ghostlight");
            this.addMaker("UM", "Unknown");
            this.addMaker("US", "Unknown");
            this.addMaker("VJ", "Unknown");
            this.addMaker("VM", "Vocabelum");
            this.addMaker("VN", "Valcon Games");
            this.addMaker("VP", "Virgin Play");
            this.addMaker("VZ", "Unknown");
            this.addMaker("WM", "Unknown");
            this.addMaker("WP", "White Park Bay Software");
            this.addMaker("WR", "Warner Bros. Entertainment");
            this.addMaker("WV", "Unknown");
            this.addMaker("XH", "Unknown");
            this.addMaker("XJ", "XSEED GAMES");
            this.addMaker("XS", "Aksys Games");
            this.addMaker("XT", "Unknown");
            this.addMaker("YM", "Unknown");
            this.addMaker("Z0", "NEONET");
            this.addMaker("Z1", "Studio9");
            this.addMaker("Z2", "Fujitsu Korea Limited");
            this.addMaker("Z3", "CTGAME Entertainment");
            this.addMaker("Z5", "Shinsegae I&C");
            this.addMaker("Z6", "Unknown");
            this.addMaker("Z7", "Unknown");
            this.addMaker("Z8", "Unknown");
            this.addMaker("Z9", "Unknown");
            this.addMaker("ZC", "Unknown");
        }

        public bool loadHeaderCacheFile(string hash)
        {
            if (hash == "")
            {
                return false;
            }
            string[] strArray3 = new string[] { "data/header_cache/", hash.Substring(0, 1), "/", hash, ".dsrhd" };
            string path = string.Concat(strArray3);
            if (!System.IO.File.Exists(path))
            {
                return false;
            }
            bool flag = false;
            string sKey = Program.form.run.hexAndMathFunction.convertHexToEncryptionKey("790077003F0028003F0050003F003F00");
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            CryptoStream stream = Program.form.encryptor.createDecryptionReadStream(sKey, fs);
            StreamReader sr = null;
            string message = "";
            try
            {
                using (sr = new StreamReader(stream))
                {
                    string str4 = this.readOneLine(sr);
                    if (int.Parse(str4.Substring("version=".Length, str4.Length - "version=".Length)) != 2)
                    {
                        flag = true;
                    }
                    if (!flag)
                    {
                        int index = 0;
                        string[] title = this.romHeader.title;
                        int num2 = 0;
                        while (true)
                        {
                            if (num2 >= title.Length)
                            {
                                str4 = this.readOneLine(sr);
                                this.romHeader.gameTitle = str4.Substring("gameTitle=".Length, str4.Length - "gameTitle=".Length);
                                str4 = this.readOneLine(sr);
                                this.romHeader.gameCode = str4.Substring("gameCode=".Length, str4.Length - "gameCode=".Length);
                                str4 = this.readOneLine(sr);
                                this.romHeader.makerCode = str4.Substring("makerCode=".Length, str4.Length - "makerCode=".Length);
                                str4 = this.readOneLine(sr);
                                this.romHeader.is3DS = bool.Parse(str4.Substring("is3DS=".Length, str4.Length - "is3DS=".Length));
                                str4 = this.readOneLine(sr);
                                this.romHeader.cardSize = int.Parse(str4.Substring("cardSize=".Length, str4.Length - "cardSize=".Length));
                                str4 = this.readOneLine(sr);
                                this.romHeader.fileSize = int.Parse(str4.Substring("fileSize=".Length, str4.Length - "fileSize=".Length));
                                str4 = this.readOneLine(sr);
                                this.romHeader.cardSize_3ds = long.Parse(str4.Substring("cardSize_3ds=".Length, str4.Length - "cardSize_3ds=".Length));
                                str4 = this.readOneLine(sr);
                                this.romHeader.fileSize_3ds = long.Parse(str4.Substring("fileSize_3ds=".Length, str4.Length - "fileSize_3ds=".Length));
                                str4 = this.readOneLine(sr);
                                this.romHeader.accurate_trim_size = long.Parse(str4.Substring("accurate_trim_size=".Length, str4.Length - "accurate_trim_size=".Length));
                                str4 = this.readOneLine(sr);
                                this.romHeader.ntr_region_rom_size = int.Parse(str4.Substring("ntr_region_rom_size=".Length, str4.Length - "ntr_region_rom_size=".Length));
                                str4 = this.readOneLine(sr);
                                this.romHeader.ntr_offset = int.Parse(str4.Substring("ntr_offset=".Length, str4.Length - "ntr_offset=".Length));
                                str4 = this.readOneLine(sr);
                                this.romHeader.ntr_size = int.Parse(str4.Substring("ntr_size=".Length, str4.Length - "ntr_size=".Length));
                                str4 = this.readOneLine(sr);
                                this.romHeader.twl_offset = int.Parse(str4.Substring("twl_offset=".Length, str4.Length - "twl_offset=".Length));
                                str4 = this.readOneLine(sr);
                                this.romHeader.twl_size = int.Parse(str4.Substring("twl_size=".Length, str4.Length - "twl_size=".Length));
                                str4 = this.readOneLine(sr);
                                this.romHeader.iconHasTrans = bool.Parse(str4.Substring("iconHasTrans=".Length, str4.Length - "iconHasTrans=".Length));
                                str4 = this.readOneLine(sr);
                                this.romHeader.isDsi = bool.Parse(str4.Substring("isDsi=".Length, str4.Length - "isDsi=".Length));
                                str4 = this.readOneLine(sr);
                                this.romHeader.wifiBlock = bool.Parse(str4.Substring("wifiBlock=".Length, str4.Length - "wifiBlock=".Length));
                                str4 = this.readOneLine(sr);
                                this.romHeader.titleId = str4.Substring("titleId=".Length, str4.Length - "titleId=".Length);
                                str4 = this.readOneLine(sr);
                                if (str4.Replace("=", "") == str4)
                                {
                                    this.romHeader.titleId = this.romHeader.titleId + str4;
                                    str4 = this.readOneLine(sr);
                                }
                                this.romHeader.hash = str4.Substring("hash=".Length, str4.Length - "hash=".Length);
                                str4 = this.readOneLine(sr);
                                this.romHeader.cleanCrc.hash = str4.Substring("cleanCrc_hash=".Length, str4.Length - "cleanCrc_hash=".Length);
                                str4 = this.readOneLine(sr);
                                this.romHeader.cleanCrc.type = (crcDupes.romTypes) int.Parse(str4.Substring("cleanCrc_type=".Length, str4.Length - "cleanCrc_type=".Length));
                                str4 = this.readOneLine(sr);
                                index = 0;
                                string[] strArray5 = str4.Substring("icon_pal=".Length, str4.Length - "icon_pal=".Length).Split(new char[] { ',' });
                                int num3 = 0;
                                while (true)
                                {
                                    if (num3 >= strArray5.Length)
                                    {
                                        str4 = this.readOneLine(sr);
                                        index = 0;
                                        string[] strArray6 = str4.Substring("icon_tiles=".Length, str4.Length - "icon_tiles=".Length).Split(new char[] { ',' });
                                        int num4 = 0;
                                        while (true)
                                        {
                                            if (num4 >= strArray6.Length)
                                            {
                                                this.romHeader.hash = hash;
                                                break;
                                            }
                                            string s = strArray6[num4];
                                            if (s != "")
                                            {
                                                this.romHeader.icon.tiles[index] = int.Parse(s);
                                                index++;
                                            }
                                            num4++;
                                        }
                                        break;
                                    }
                                    string str5 = strArray5[num3];
                                    if (str5 != "")
                                    {
                                        this.romHeader.icon.pal[index] = str5;
                                        index++;
                                    }
                                    num3++;
                                }
                                break;
                            }
                            string text1 = title[num2];
                            str4 = this.readOneLine(sr);
                            this.romHeader.title[index] = str4.Substring(("title_" + index + "=").Length, str4.Length - ("title_" + index + "=").Length);
                            index++;
                            num2++;
                        }
                    }
                }
                sr.Close();
            }
            catch (Exception exception1)
            {
                message = exception1.Message;
                if (sr != null)
                {
                    sr.Close();
                }
                flag = true;
            }
            fs.Close();
            if (this.romHeader.gameTitle.Substring(0, 6) == "377ABC")
            {
                message = "7z Header found";
                flag = true;
            }
            if (flag)
            {
                MessageBox.Show("The header cache file appears to be corrupted.\r\nThe error message was:\r\n\r\n" + message + "\r\n\r\nThe header will be reloaded in full.", "Header Cache File Corrupted", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            return !flag;
        }

        public unsafe void loadRomHeader(string file, bool batch)
        {
            if (this.loadHeaderCacheFile(this.romHeader.hash))
            {
                this.romHeader.loaded = true;
            }
            else
            {
                this.deleteHeaderCacheFile(this.romHeader.hash);
                if (file.ToLower().EndsWith("3ds"))
                {
                    this.loadRomHeader_3DS(file, batch);
                }
                else
                {
                    string hash = this.romHeader.hash;
                    this.romHeader = new romHeader_HeaderClass();
                    this.romHeader.is3DS = false;
                    this.romHeader.loaded = false;
                    this.romHeader.hash = hash;
                    try
                    {
                        FileStream input = System.IO.File.Open(file, FileMode.Open);
                        long pos = 0L;
                        string hex = null;
                        using (BinaryReader reader = new BinaryReader(input, Encoding.BigEndianUnicode))
                        {
                            int num5;
                            int num10;
                            this.romHeader.gameTitle = "";
                            this.romHeader.fileSize = (int) reader.BaseStream.Length;
                            int num2 = 0;
                            while (true)
                            {
                                if (num2 < 12)
                                {
                                    hex = this.readHex(reader, &pos, 1);
                                    if (hex != null)
                                    {
                                        this.romHeader.gameTitle = this.romHeader.gameTitle + hex;
                                        num2++;
                                        continue;
                                    }
                                    this.failedLoad("1", batch);
                                    input.Close();
                                    return;
                                }
                                else
                                {
                                    this.romHeader.gameCode = "";
                                    int num3 = 0;
                                    while (true)
                                    {
                                        if (num3 < 4)
                                        {
                                            hex = this.readHex(reader, &pos, 1);
                                            if (hex != null)
                                            {
                                                this.romHeader.gameCode = this.romHeader.gameCode + hex;
                                                num3++;
                                                continue;
                                            }
                                            this.failedLoad("2", batch);
                                            input.Close();
                                            return;
                                        }
                                        else
                                        {
                                            this.romHeader.gameCode = this.run.hexAndMathFunction.hexToString(this.romHeader.gameCode);
                                            hex = this.readHex(reader, &pos, 2);
                                            if (hex != null)
                                            {
                                                this.romHeader.makerCode = this.run.hexAndMathFunction.hexToString(hex);
                                                if (this.readHex(reader, &pos, 2) != null)
                                                {
                                                    hex = this.readHex(reader, &pos, 1);
                                                    if (hex != null)
                                                    {
                                                        this.romHeader.cardSize = int.Parse(hex, NumberStyles.HexNumber);
                                                        while (true)
                                                        {
                                                            if (pos < 0x68)
                                                            {
                                                                if (this.skipBytes(reader, &pos, (int) (0x68 - pos)))
                                                                {
                                                                    continue;
                                                                }
                                                                this.failedLoad("6", batch);
                                                                input.Close();
                                                                return;
                                                            }
                                                            else
                                                            {
                                                                string str3 = this.readHex(reader, &pos, 4);
                                                                if (str3 != null)
                                                                {
                                                                    while (true)
                                                                    {
                                                                        if (pos < 0x80L)
                                                                        {
                                                                            if (this.skipBytes(reader, &pos, (int) (0x80L - pos)))
                                                                            {
                                                                                continue;
                                                                            }
                                                                            this.failedLoad("8", batch);
                                                                            input.Close();
                                                                            return;
                                                                        }
                                                                        else
                                                                        {
                                                                            hex = this.readHex(reader, &pos, 4);
                                                                            if (hex != null)
                                                                            {
                                                                                this.romHeader.ntr_region_rom_size = int.Parse(Program.form.run.hexAndMathFunction.reversehex(hex, 8), NumberStyles.HexNumber);
                                                                                while (true)
                                                                                {
                                                                                    if (pos < 230L)
                                                                                    {
                                                                                        if (this.skipBytes(reader, &pos, (int) (230L - pos)))
                                                                                        {
                                                                                            continue;
                                                                                        }
                                                                                        this.failedLoad("10", batch);
                                                                                        input.Close();
                                                                                        return;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        this.romHeader.titleId = "";
                                                                                        int num4 = 0;
                                                                                        while (true)
                                                                                        {
                                                                                            if (num4 < 8)
                                                                                            {
                                                                                                hex = this.readHex(reader, &pos, 1);
                                                                                                if (hex != null)
                                                                                                {
                                                                                                    this.romHeader.titleId = this.romHeader.titleId + hex;
                                                                                                    num4++;
                                                                                                    continue;
                                                                                                }
                                                                                                this.failedLoad("11", batch);
                                                                                                input.Close();
                                                                                                return;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                this.romHeader.titleId = this.run.hexAndMathFunction.hexToString(this.romHeader.titleId);
                                                                                                while (true)
                                                                                                {
                                                                                                    if (pos < 480L)
                                                                                                    {
                                                                                                        if (this.skipBytes(reader, &pos, (int) (0x1e8L - pos)))
                                                                                                        {
                                                                                                            continue;
                                                                                                        }
                                                                                                        this.failedLoad("12", batch);
                                                                                                        input.Close();
                                                                                                        return;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        hex = this.readHex(reader, &pos, 4);
                                                                                                        if (hex != null)
                                                                                                        {
                                                                                                            this.romHeader.ntr_offset = int.Parse(Program.form.run.hexAndMathFunction.reversehex(hex, 8), NumberStyles.HexNumber);
                                                                                                            hex = this.readHex(reader, &pos, 4);
                                                                                                            if (hex != null)
                                                                                                            {
                                                                                                                this.romHeader.ntr_size = int.Parse(Program.form.run.hexAndMathFunction.reversehex(hex, 8), NumberStyles.HexNumber);
                                                                                                                hex = this.readHex(reader, &pos, 4);
                                                                                                                if (hex != null)
                                                                                                                {
                                                                                                                    this.romHeader.twl_offset = int.Parse(Program.form.run.hexAndMathFunction.reversehex(hex, 8), NumberStyles.HexNumber);
                                                                                                                    this.romHeader.isDsi = this.romHeader.twl_offset != 0;
                                                                                                                    hex = this.readHex(reader, &pos, 4);
                                                                                                                    if (hex != null)
                                                                                                                    {
                                                                                                                        this.romHeader.twl_size = int.Parse(Program.form.run.hexAndMathFunction.reversehex(hex, 8), NumberStyles.HexNumber);
                                                                                                                        num5 = this.run.hexAndMathFunction.hexToInt(str3);
                                                                                                                        if ((pos < num5) && !this.skipBytes(reader, &pos, num5 - ((int) pos)))
                                                                                                                        {
                                                                                                                            this.failedLoad("17", batch);
                                                                                                                            input.Close();
                                                                                                                            return;
                                                                                                                        }
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        this.failedLoad("16", batch);
                                                                                                                        input.Close();
                                                                                                                        return;
                                                                                                                    }
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    this.failedLoad("15", batch);
                                                                                                                    input.Close();
                                                                                                                    return;
                                                                                                                }
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                this.failedLoad("14", batch);
                                                                                                                input.Close();
                                                                                                                return;
                                                                                                            }
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            this.failedLoad("13", batch);
                                                                                                            input.Close();
                                                                                                            return;
                                                                                                        }
                                                                                                    }
                                                                                                    break;
                                                                                                }
                                                                                            }
                                                                                            break;
                                                                                        }
                                                                                    }
                                                                                    break;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                this.failedLoad("9", batch);
                                                                                input.Close();
                                                                                return;
                                                                            }
                                                                        }
                                                                        break;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    this.failedLoad("7", batch);
                                                                    input.Close();
                                                                    return;
                                                                }
                                                            }
                                                            break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        this.failedLoad("5", batch);
                                                        input.Close();
                                                        return;
                                                    }
                                                }
                                                else
                                                {
                                                    this.failedLoad("4", batch);
                                                    input.Close();
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                this.failedLoad("3", batch);
                                                input.Close();
                                                return;
                                            }
                                        }
                                        break;
                                    }
                                }
                                break;
                            }
                            goto TR_0055;
                        TR_001F:
                            this.romHeader.wifiBlock = false;
                            if (pos < reader.BaseStream.Length)
                            {
                                int num13 = 0;
                                while (true)
                                {
                                    if (num13 < 0x88)
                                    {
                                        hex = this.readHex(reader, &pos, 1);
                                        if ((hex == "FF") || (hex == "00"))
                                        {
                                            num13++;
                                            continue;
                                        }
                                        this.romHeader.wifiBlock = true;
                                    }
                                    if (this.romHeader.wifiBlock)
                                    {
                                        this.romHeader.accurate_trim_size += 0x88L;
                                    }
                                    break;
                                }
                            }
                            goto TR_0014;
                        TR_0038:
                            while (true)
                            {
                                if (num10 < 6)
                                {
                                    this.romHeader.title[num10] = "";
                                    int num11 = 0;
                                    while (true)
                                    {
                                        if (num11 < 0x100)
                                        {
                                            hex = this.readHex(reader, &pos, 1);
                                            if (hex != null)
                                            {
                                                string[] strArray;
                                                IntPtr ptr;
                                                (strArray = this.romHeader.title)[(int) (ptr = (IntPtr) num10)] = strArray[(int) ptr] + hex;
                                                num11++;
                                                continue;
                                            }
                                            this.failedLoad("21", batch);
                                            input.Close();
                                        }
                                        else
                                        {
                                            num10++;
                                            continue;
                                        }
                                        break;
                                    }
                                }
                                else
                                {
                                    goto TR_0055;
                                }
                                break;
                            }
                            return;
                        TR_0055:
                            while (true)
                            {
                                if ((pos - num5) < 0x840L)
                                {
                                    long num14 = pos - num5;
                                    if (num14 == 0x20)
                                    {
                                        if (2 == 0)
                                        {
                                            hex = this.readHex(reader, &pos, 0x200);
                                            if (hex != null)
                                            {
                                                hex = this.run.hexAndMathFunction.reversehex(hex, 0x400);
                                                for (int i = 0; i < 0x400; i++)
                                                {
                                                    this.romHeader.icon.tiles[i] = int.Parse(hex.Substring(i, 1), NumberStyles.HexNumber);
                                                }
                                                continue;
                                            }
                                            this.failedLoad("18", batch);
                                            input.Close();
                                        }
                                        else
                                        {
                                            hex = this.readHex(reader, &pos, 0x200);
                                            if (hex != null)
                                            {
                                                for (int i = 0; i < 0x200; i++)
                                                {
                                                    this.romHeader.icon.tiles[i * 2] = int.Parse(hex.Substring((i * 2) + 1, 1), NumberStyles.HexNumber);
                                                    this.romHeader.icon.tiles[(i * 2) + 1] = int.Parse(hex.Substring(i * 2, 1), NumberStyles.HexNumber);
                                                }
                                                continue;
                                            }
                                            this.failedLoad("19", batch);
                                            input.Close();
                                        }
                                        return;
                                    }
                                    else if (num14 == 0x220L)
                                    {
                                        int index = 0;
                                        while (true)
                                        {
                                            if (index < 0x10)
                                            {
                                                hex = this.readHex(reader, &pos, 2);
                                                if (hex != null)
                                                {
                                                    this.romHeader.icon.pal[index] = hex;
                                                    index++;
                                                    continue;
                                                }
                                                this.failedLoad("20", batch);
                                                input.Close();
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                            break;
                                        }
                                        return;
                                    }
                                    else if (num14 == 0x240L)
                                    {
                                        num10 = 0;
                                    }
                                    else
                                    {
                                        if (this.skipBytes(reader, &pos, 1))
                                        {
                                            continue;
                                        }
                                        this.failedLoad("22", batch);
                                        input.Close();
                                        return;
                                    }
                                }
                                else
                                {
                                    this.romHeader.accurate_trim_size = this.romHeader.fileSize;
                                    if (this.romHeader.ntr_region_rom_size > 0)
                                    {
                                        this.romHeader.accurate_trim_size = this.romHeader.ntr_region_rom_size;
                                    }
                                    if ((this.romHeader.ntr_offset + this.romHeader.ntr_size) > this.romHeader.accurate_trim_size)
                                    {
                                        this.romHeader.accurate_trim_size = this.romHeader.ntr_offset + this.romHeader.ntr_size;
                                    }
                                    if ((this.romHeader.twl_offset + this.romHeader.twl_size) > this.romHeader.accurate_trim_size)
                                    {
                                        this.romHeader.accurate_trim_size = this.romHeader.twl_offset + this.romHeader.twl_size;
                                    }
                                    int length = (int) this.romHeader.accurate_trim_size;
                                    if (pos >= length)
                                    {
                                        goto TR_001F;
                                    }
                                    else
                                    {
                                        if (length > ((int) reader.BaseStream.Length))
                                        {
                                            length = (int) reader.BaseStream.Length;
                                        }
                                        if (this.skipBytes(reader, &pos, length - ((int) pos)))
                                        {
                                            goto TR_001F;
                                        }
                                        else
                                        {
                                            this.failedLoad("23", batch);
                                            input.Close();
                                        }
                                    }
                                    return;
                                }
                                break;
                            }
                            goto TR_0038;
                        }
                        return;
                    TR_0014:
                        input.Close();
                        if (!batch)
                        {
                            this.saveHeaderCacheFile();
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message ?? "");
                        this.failedLoad("24\n\n" + exception.Message, batch);
                    }
                    this.romHeader.loaded = true;
                }
            }
        }

        public unsafe void loadRomHeader_3DS(string file, bool batch)
        {
            string hash = this.romHeader.hash;
            this.romHeader = new romHeader_HeaderClass();
            this.romHeader.is3DS = true;
            this.romHeader.loaded = false;
            this.romHeader.hash = hash;
            try
            {
                FileStream input = System.IO.File.Open(file, FileMode.Open);
                long num = 0x4000L;
                long num2 = 0x200L;
                long pos = 0L;
                string hex = null;
                using (BinaryReader reader = new BinaryReader(input, Encoding.BigEndianUnicode))
                {
                    while (true)
                    {
                        if (pos < 260L)
                        {
                            if (this.skipBytes(reader, &pos, (int) (260L - pos)))
                            {
                                continue;
                            }
                            this.failedLoad("1", batch);
                            input.Close();
                        }
                        else
                        {
                            hex = this.readHex(reader, &pos, 4);
                            if (hex != null)
                            {
                                this.romHeader.cardSize_3ds = long.Parse(this.run.hexAndMathFunction.reversehex(hex, 8), NumberStyles.HexNumber) * num2;
                                while (true)
                                {
                                    if (pos < 0x300L)
                                    {
                                        if (this.skipBytes(reader, &pos, (int) (0x300L - pos)))
                                        {
                                            continue;
                                        }
                                        this.failedLoad("3", batch);
                                        input.Close();
                                    }
                                    else
                                    {
                                        hex = this.readHex(reader, &pos, 4);
                                        if (hex != null)
                                        {
                                            this.romHeader.accurate_trim_size = long.Parse(this.run.hexAndMathFunction.reversehex(hex, 8), NumberStyles.HexNumber);
                                            while (true)
                                            {
                                                if (pos < num)
                                                {
                                                    if (this.skipBytes(reader, &pos, (int) (num - pos)))
                                                    {
                                                        continue;
                                                    }
                                                    this.failedLoad("5", batch);
                                                    input.Close();
                                                }
                                                else
                                                {
                                                    while (true)
                                                    {
                                                        if (pos < 0x4110L)
                                                        {
                                                            if (this.skipBytes(reader, &pos, (int) (0x4110L - pos)))
                                                            {
                                                                continue;
                                                            }
                                                            this.failedLoad("6", batch);
                                                            input.Close();
                                                        }
                                                        else
                                                        {
                                                            hex = this.readHex(reader, &pos, 2);
                                                            if (hex != null)
                                                            {
                                                                this.romHeader.makerCode = this.run.hexAndMathFunction.hexToString(hex);
                                                                while (true)
                                                                {
                                                                    if (pos < 0x4118L)
                                                                    {
                                                                        if (this.skipBytes(reader, &pos, (int) (0x4118L - pos)))
                                                                        {
                                                                            continue;
                                                                        }
                                                                        this.failedLoad("8", batch);
                                                                        input.Close();
                                                                    }
                                                                    else
                                                                    {
                                                                        this.romHeader.gameTitle = "";
                                                                        this.romHeader.fileSize_3ds = reader.BaseStream.Length;
                                                                        this.romHeader.fileSize = -1;
                                                                        int num4 = 0;
                                                                        while (true)
                                                                        {
                                                                            if (num4 < 8)
                                                                            {
                                                                                hex = this.readHex(reader, &pos, 1);
                                                                                if (hex != null)
                                                                                {
                                                                                    this.romHeader.gameTitle = this.romHeader.gameTitle + hex;
                                                                                    num4++;
                                                                                    continue;
                                                                                }
                                                                                this.failedLoad("9", batch);
                                                                                input.Close();
                                                                            }
                                                                            else
                                                                            {
                                                                                while (true)
                                                                                {
                                                                                    if (pos < 0x4150L)
                                                                                    {
                                                                                        if (this.skipBytes(reader, &pos, (int) (0x4150L - pos)))
                                                                                        {
                                                                                            continue;
                                                                                        }
                                                                                        this.failedLoad("10", batch);
                                                                                        input.Close();
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        this.romHeader.gameCode = "";
                                                                                        int num5 = 0;
                                                                                        while (true)
                                                                                        {
                                                                                            if (num5 < 0x10)
                                                                                            {
                                                                                                hex = this.readHex(reader, &pos, 1);
                                                                                                if (hex != null)
                                                                                                {
                                                                                                    this.romHeader.gameCode = this.romHeader.gameCode + hex;
                                                                                                    num5++;
                                                                                                    continue;
                                                                                                }
                                                                                                this.failedLoad("11", batch);
                                                                                                input.Close();
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                this.romHeader.gameCode = this.run.hexAndMathFunction.hexToString(this.romHeader.gameCode);
                                                                                                while (true)
                                                                                                {
                                                                                                    if (pos < 0x4188L)
                                                                                                    {
                                                                                                        if (this.skipBytes(reader, &pos, (int) (0x4188L - pos)))
                                                                                                        {
                                                                                                            continue;
                                                                                                        }
                                                                                                        this.failedLoad("12", batch);
                                                                                                        input.Close();
                                                                                                    }
                                                                                                    else if (this.readHex(reader, &pos, 8) != null)
                                                                                                    {
                                                                                                        while (true)
                                                                                                        {
                                                                                                            if (pos < 0x4190L)
                                                                                                            {
                                                                                                                if (this.skipBytes(reader, &pos, (int) (0x4190L - pos)))
                                                                                                                {
                                                                                                                    continue;
                                                                                                                }
                                                                                                                this.failedLoad("14", batch);
                                                                                                                input.Close();
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                hex = this.readHex(reader, &pos, 4);
                                                                                                                if (hex != null)
                                                                                                                {
                                                                                                                    long num6 = (Program.form.run.hexAndMathFunction.hexToLong(hex) * num2) + num;
                                                                                                                    hex = this.readHex(reader, &pos, 4);
                                                                                                                    if (hex != null)
                                                                                                                    {
                                                                                                                        long num7 = Program.form.run.hexAndMathFunction.hexToLong(hex) * num2;
                                                                                                                        while (true)
                                                                                                                        {
                                                                                                                            if (pos < num6)
                                                                                                                            {
                                                                                                                                if (this.skipBytes(reader, &pos, (int) (num6 - pos)))
                                                                                                                                {
                                                                                                                                    continue;
                                                                                                                                }
                                                                                                                                this.failedLoad("16", batch);
                                                                                                                                input.Close();
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                this.romHeader.title[0] = "";
                                                                                                                                int num8 = 0;
                                                                                                                                while (true)
                                                                                                                                {
                                                                                                                                    if (num8 < num7)
                                                                                                                                    {
                                                                                                                                        hex = this.readHex(reader, &pos, 1);
                                                                                                                                        if (hex != null)
                                                                                                                                        {
                                                                                                                                            string[] strArray;
                                                                                                                                            (strArray = this.romHeader.title)[0] = strArray[0] + hex;
                                                                                                                                            num8++;
                                                                                                                                            continue;
                                                                                                                                        }
                                                                                                                                        this.failedLoad("17", batch);
                                                                                                                                        input.Close();
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        goto TR_000D;
                                                                                                                                    }
                                                                                                                                    break;
                                                                                                                                }
                                                                                                                            }
                                                                                                                            break;
                                                                                                                        }
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        this.failedLoad("15", batch);
                                                                                                                        input.Close();
                                                                                                                    }
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    this.failedLoad("15", batch);
                                                                                                                    input.Close();
                                                                                                                }
                                                                                                            }
                                                                                                            break;
                                                                                                        }
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        this.failedLoad("13", batch);
                                                                                                        input.Close();
                                                                                                    }
                                                                                                    break;
                                                                                                }
                                                                                            }
                                                                                            break;
                                                                                        }
                                                                                    }
                                                                                    break;
                                                                                }
                                                                            }
                                                                            break;
                                                                        }
                                                                    }
                                                                    break;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                this.failedLoad("7", batch);
                                                                input.Close();
                                                            }
                                                        }
                                                        break;
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            this.failedLoad("2", batch);
                                            input.Close();
                                        }
                                    }
                                    break;
                                }
                            }
                            else
                            {
                                this.failedLoad("2", batch);
                                input.Close();
                            }
                        }
                        break;
                    }
                }
                return;
            TR_000D:
                input.Close();
                if (!batch)
                {
                    this.saveHeaderCacheFile();
                }
            }
            catch (Exception exception)
            {
                this.failedLoad("24\n\n" + exception.Message, batch);
            }
            this.romHeader.loaded = true;
        }

        public string makerNameFromCode(string code)
        {
            string str = "";
            str = (code != "") ? "Unknown" : "Homebrew";
            for (int i = 0; i < 0x400; i++)
            {
                if ((this.makers[i] != null) && ((code != "") && (this.makers[i].code.ToUpper().Substring(0, 2) == code.ToUpper().Substring(0, 2))))
                {
                    return this.makers[i].name;
                }
            }
            return str;
        }

        public unsafe string readHex(BinaryReader br, long* pos, int bytes)
        {
            StringBuilder builder = new StringBuilder();
            if ((pos[0] + bytes) > br.BaseStream.Length)
            {
                MessageBox.Show("Tried to read beyond the end of the file at offset 0x" + $"{pos[0]:X8}");
                return null;
            }
            int num = 0;
            goto TR_0007;
        TR_0001:
            return builder.ToString();
        TR_0007:
            while (true)
            {
                if (num < bytes)
                {
                    try
                    {
                        builder.Append(((int) br.ReadByte()).ToString("X2"));
                        pos[0] += 1L;
                        break;
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("error: " + exception.Message);
                    }
                    goto TR_0001;
                }
                else
                {
                    goto TR_0001;
                }
                break;
            }
            num++;
            goto TR_0007;
        }

        public string readOneLine(StreamReader sr)
        {
            string str = sr.ReadLine();
            return ((str != "") ? (!str.StartsWith("//") ? str : this.readOneLine(sr)) : this.readOneLine(sr));
        }

        public void saveHeaderCacheFile()
        {
            if (this.romHeader.hash != "")
            {
                if (!Directory.Exists("data/header_cache/" + this.romHeader.hash.Substring(0, 1) + "/"))
                {
                    Directory.CreateDirectory("data/header_cache/" + this.romHeader.hash.Substring(0, 1) + "/");
                }
                string str = "data/header_cache/" + this.romHeader.hash.Substring(0, 1) + "/" + this.romHeader.hash;
                StreamWriter writer = new StreamWriter(System.IO.File.OpenWrite(str + ".txt"));
                int num = 0;
                writer.WriteLine("version=" + 2);
                foreach (string str2 in this.romHeader.title)
                {
                    string str3 = (str2 != null) ? str2 : "";
                    writer.WriteLine(string.Concat(new object[] { "title_", num, "=", str3 }));
                    num++;
                }
                writer.WriteLine("gameTitle=" + this.romHeader.gameTitle);
                writer.WriteLine("gameCode=" + this.romHeader.gameCode);
                writer.WriteLine("makerCode=" + this.romHeader.makerCode);
                writer.WriteLine("is3DS=" + this.romHeader.is3DS);
                writer.WriteLine("cardSize=" + this.romHeader.cardSize);
                writer.WriteLine("fileSize=" + this.romHeader.fileSize);
                writer.WriteLine("cardSize_3ds=" + this.romHeader.cardSize_3ds);
                writer.WriteLine("fileSize_3ds=" + this.romHeader.fileSize_3ds);
                writer.WriteLine("accurate_trim_size=" + this.romHeader.accurate_trim_size);
                writer.WriteLine("ntr_region_rom_size=" + this.romHeader.ntr_region_rom_size);
                writer.WriteLine("ntr_offset=" + this.romHeader.ntr_offset);
                writer.WriteLine("ntr_size=" + this.romHeader.ntr_size);
                writer.WriteLine("twl_offset=" + this.romHeader.twl_offset);
                writer.WriteLine("twl_size=" + this.romHeader.twl_size);
                writer.WriteLine("iconHasTrans=" + this.romHeader.iconHasTrans);
                writer.WriteLine("isDsi=" + this.romHeader.isDsi);
                writer.WriteLine("wifiBlock=" + this.romHeader.wifiBlock);
                writer.WriteLine("titleId=" + this.romHeader.titleId);
                writer.WriteLine("hash=" + this.romHeader.hash);
                writer.WriteLine("cleanCrc_hash=" + this.romHeader.cleanCrc.hash);
                writer.WriteLine("cleanCrc_type=" + ((int) this.romHeader.cleanCrc.type));
                writer.Write("icon_pal=");
                foreach (string str4 in this.romHeader.icon.pal)
                {
                    writer.Write(str4 + ",");
                }
                writer.Write("\r\n");
                writer.Write("icon_tiles=");
                foreach (int num2 in this.romHeader.icon.tiles)
                {
                    writer.Write(num2 + ",");
                }
                writer.Write("\r\n");
                writer.Close();
                string sKey = Program.form.run.hexAndMathFunction.convertHexToEncryptionKey("790077003F0028003F0050003F003F00");
                Program.form.encryptor.EncryptFile(str + ".txt", str + ".dsrhd", sKey, GCHandle.Alloc(sKey, GCHandleType.Pinned));
                System.IO.File.Delete(str + ".txt");
            }
        }

        public unsafe bool skipBytes(BinaryReader br, long* pos, int bytes)
        {
            if ((pos[0] + bytes) > br.BaseStream.Length)
            {
                return false;
            }
            br.ReadBytes(bytes);
            pos[0] += bytes;
            return true;
        }

        public class Country
        {
            public string code = "";
            public string name = "";
        }

        public class Maker
        {
            public string code = "";
            public string name = "";
        }

        public class romHeader_HeaderClass
        {
            public string[] title = new string[6];
            public string gameTitle = "";
            public string gameCode = "";
            public string makerCode = "";
            public string makerName = "";
            public bool is3DS;
            public int cardSize;
            public int fileSize;
            public long cardSize_3ds;
            public long fileSize_3ds;
            public long accurate_trim_size;
            public int ntr_region_rom_size;
            public int ntr_offset;
            public int ntr_size;
            public int twl_offset;
            public int twl_size;
            public dsromHeader.romIcon_Class icon = new dsromHeader.romIcon_Class();
            public bool iconHasTrans;
            public bool loaded;
            public bool isDsi;
            public bool wifiBlock;
            public string titleId = "";
            public string hash = "";
            public bool website_knows_it;
            public crcDupes.possibleCrcType cleanCrc = new crcDupes.possibleCrcType();
        }

        public class romIcon_Class
        {
            public string[] pal = new string[0x10];
            public int[] tiles = new int[0x400];
            public Bitmap gfx = new Bitmap(0x20, 0x20);
        }

        public class runFunctionsType
        {
            public hexAndMathFunctions hexAndMathFunction = new hexAndMathFunctions();
        }
    }
}

