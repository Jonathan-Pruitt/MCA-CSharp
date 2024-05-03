using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace test2 {

    #region CLASSES 
    public class Animal {
        public string name = "";
        public string sound = "";
        public int age      = 0;
        private int stomachCapacity = 100;
        private int currentFullness = 0;

        public void MakeNoise() {
            Console.WriteLine(sound);
        }//end function

        public void Eat(int amountOfFood) {
            currentFullness += amountOfFood;
            Console.WriteLine($"{name} is {currentFullness}% full");
            if (currentFullness > stomachCapacity) {
                Vomit();
            }//end if
        }//end function

        private void Vomit() {            
            while (currentFullness > stomachCapacity) {
                currentFullness -= 15;
                Console.WriteLine($"{name} vomited 15 units of food..  :(");
            }//end while
        }//end method        

    }//end Animal Class

    public class Refrigerator {
        #region FIELDS (BACKING FIELDS)
        double  _temp = 0;
        string  _model = "";
        string  _contents = "";
        bool    _hasFreezer = false;
        #endregion

        #region CONSTRUCTOR
        public Refrigerator (string modelName) {
            _model = modelName;
            _temp = 35;
        }//end constructor

        public Refrigerator (string modelName, bool withFreezer) {
            _model = modelName;
            _hasFreezer = withFreezer;
            _temp = 35;
        }//end constructor

        public Refrigerator() {

        }//end constructor
        #endregion

        public void Cool() {
            _temp -= 2;            
        }//end method

        //MUTATOR METHOD SETS A NEW VALUE TO A FIELD
        public void SetModel(string modelName) {
            _model = modelName;
        }//end method

        //ACCESSOR METHOD GETS THE VALUE OF A FIELD
        public string GetModel() {
            return _model;
        }//end method

        public void AddItem(string item) {
            _contents += item + " ";
        }//end method

        public void CheckContents() {
            Console.WriteLine(_contents);
        }//end method
    }//end class

    //THIS CLASS DEFINES A POINT IN A 2 DIMENSIONAL SPACE
    public class Point {
        //FIELDS
            //FIELDS ARE THE PRIVATE VARIABLES THAT REPRESENT THE PROPERTIES OF THE CLASS
            int _x = 0; //BOTH OF THESE FIELDS DEFAULT TO PRIVATE UNLESS EXPLICITLY --
            int _y = 0; // -- DEFINED AS PUBLIC WHEN DECLARED

        //CONSTRUCTOR
            //THE CONSTRUCTOR IS CALLED ONCE WHEN AN INSTANCE OF THE CLASS IS CREATED
            // TYPICALLY, THE CONSTRUCTOR SETS UP INITIAL VALUES FOR THE OBJECT
            public Point(int xLocation, int yLocation) {
                _x = xLocation;
                _y = yLocation;
            }//end constructor

        //PROPERTIES
            //PROPERTIES CONTROL ACCESS TO THE VALUES OF THE BACKING FIELDS
            public int X {
                get {return _x;}
                set {_x = value;}
            }//end X Property
            public int Y {
                get {return _y;}
                set {_y = value;}
            }//end Y Property

        //METHODS
            //METHODS GIVE FUNCTIONALITY TO A CLASS. THEY CAN ALSO CONTROL
            // ACCESS TO THE BACKING FIELDS

            //SETPOINT UPDATES THE VALUE OF X AND Y TO NEW POSITION
            //SETPOINT IS A MUTATOR METHOD
            public void SetPoint(int xLoc, int yLoc) {
                _x = xLoc;
                _y = yLoc;
            }//end method
            
            //POINTTOSTRING RETURNS A STRING WITH THE POINT'S INFORMATION
            //POINTTOSTRING IS A MUTATOR METHOD
            public string PointToString() {
                return $"X-{_x} :: Y-{_y}";
            }//end method

            //MOVEHORIZONTAL UPDATES THE X POSITION RELATIVE TO ITS CURRENT POSITION
            public void MoveHorizontal(int spaces) {
                _x += spaces;
            }//end method

            //MOVEVARTICAL UPDATES THE Y POSITION RELATIVE TO ITS CURRENT POSITION
            public void MoveVertical(int spaces) {
                _y += spaces;
            }//end method

    }//end class

    #endregion

    internal class Program {
        static void Main(string[] args) {

            Refrigerator[] fridges = new Refrigerator[4];
            for (int i = 0; i < fridges.Length; i++) {
                fridges[i] = new Refrigerator();
                fridges[i].SetModel($"{i}XF{i+25}");
            }//end for

            foreach (Refrigerator unit in fridges) {
                Console.WriteLine(unit.GetModel());
            }//end loop
            
            
        }//end main

        #region FILE INPUT/OUTPUT AND STRING MANIPULATION
        static void PigLatinAttempt() {
            //OPEN FILE
            FileStream file = new FileStream("C:\\Users\\jonat\\Documents\\WORK\\C# 3Month Lesson Plan\\Week 10\\speech.txt", FileMode.Open);
            string text = "";

            //USE A LOOP TO ITERATE THROUGH ALL BYTES OF FILE
            while (file.Position < file.Length) {
                //READ A BYTE FROM FILE AND CAST IT AS A BYTE - STORE TO 'data'
                byte data = (byte)file.ReadByte();

                //WRITE THE BYTE TO THE CONSOLE BY CASTING IT AS A CHAR
                text += (char)data;

                //INCREASE THE BYTE COUNTER BY 1
            }//end loop

            //CLOSE THE FILE
            file.Close();

            //BEGIN PIGGY
            //string text = "Will this work for me? Because if it doesn't I'll be pretty fucking mad!!!";
            string[] separatedText = text.Split();
            string finalText = "";

            for (int i = 0; i < separatedText.Length; i++) {
                finalText += Pigify(separatedText[i]) + " ";
            }//end for

            Console.WriteLine(finalText.ToUpper());

            static string Pigify(string word) {
                if (word == "") {
                    return "";
                }
                string pigged = "";
                int lastChar = -1;
                char[] vowels = {'a','e','i','o','u'};
                bool isVowel = false;
                //CHECK FOR LAST LOCATION OF ALPHABET CHAR
                for (int i = word.Length - 1; i >= 0; i--) {
                    if ((word[i] >= 'a' && word[i] <= 'z') || (word[i] >= 'A' && word[i] <= 'Z')) {
                        lastChar = i;
                        break;
                    }//end if
                }//end for

                for (int i = 0; i < vowels.Length; i++) {
                    if (char.ToLower(word[0]) == vowels[i]) {
                        isVowel = true;
                    }//end if
                }//end for

                if (isVowel) {
                    for (int i = 0; i < word.Length; i++) {
                        pigged += word[i];
                        if (i == lastChar) {
                            pigged += "way";
                        }//end if
                    }//end for                    
                } else {
                    for (int i = 1; i < word.Length; i++) {
                        pigged += word[i];
                        if (i == lastChar) {
                            pigged += word[0] + "ay";
                        }//end if
                    }//end for 
                }//end if
                return pigged;
            }//end localFunc
        }//end function

        static void FileIntake() {

        //BEGIN READING FILE INTO PROGRAM
            FileStream infile = File.OpenRead(@"C:\Users\jonat\Desktop\test.txt");
            string arriving = "";

            for (int i = 0; i < infile.Length; i++) {
                arriving += (char)infile.ReadByte();
            }//end for

            infile.Close();
        //END READING FILE INTO PROGRAM

        }//end function

        static string UpCase(string incoming) {
            //DECLARE VARIABLES
            string upperCased = "";
            char[] buffer = incoming.ToCharArray();            

            for (int i = 0; i < buffer.Length; i++) {
                char c = buffer[i];
                if (c >= 'a' && c <= 'z') {
                    upperCased += (char)(c - 32);
                } else {
                    upperCased += c;
                }//end if
            }//end for
            
            return upperCased;
        }//end function

        static void StringManip() {
            string text = "Hello";
            char[] buffer = text.ToCharArray();
            string finalText = "";

            buffer[0] = 'J';
            
            for (int l = 0; l < buffer.Length; l++) {
                finalText += buffer[l];
                // finalText = finalText + buffer[l];
            }//end function

            Console.WriteLine(finalText);
        }//end function

        static void TextFileAccess() {
            
            #region WRITING TO FILE
            //DECLARE VARIABLE
            string text = "I had a very good weekend!";

            //CREATE A STREAMWRITER OBJECT
            StreamWriter outfile = new StreamWriter("C:\\Users\\jonat\\Desktop\\test.txt");

            //WRITE TEXT OUT TO A FILE
            outfile.Write(text);
            
            //CLOSE THE FILE
            outfile.Close();
            #endregion
            

            //CREATE A STREAMREADER OBJECT
            StreamReader infile = new StreamReader("C:\\Users\\jonat\\Desktop\\test.txt");

            int count = 0;
            //READ EACH CHARACTER INTO THE PROGRAM AS A CHAR
            while (infile.EndOfStream != true) {
                char fileInfo = (char)infile.Read();            
                Console.WriteLine(fileInfo);
                count++;
            }//end while
            Console.WriteLine(count);
        }//end function

        static void BinaryFileAccess() {
            //DECLARE VARIABLES
            //CREATE A FILESTREAM OBJECT
            FileStream outfile = new FileStream("C:\\Users\\jonat\\Desktop\\test.txt", FileMode.OpenOrCreate);
            
            //CREATE TEXT
            string text = "Open the door. Get on the floor. Everybody walk the dinosaur";
            char[] buffer = text.ToCharArray();

            //LOOP THROUGH THE CHAR ARRAY AND WRITE TO FILE
            for (int c = 0; c < buffer.Length; c++) {
                byte data = (byte)buffer[c];
                outfile.WriteByte(data);
            }//end loop

            //CLOSE FILE
            outfile.Close();

            //READ DATA FROM A FILE
            //CREATE A FILESTREAM OBJECT
            FileStream infile = new FileStream("C:\\Users\\jonat\\Pictures\\exampleForSara.bmp", FileMode.Open);
            int count = 0;

            //LOOP THROUGH THE READPOSITION OF OUR FILE
            while (infile.Position < infile.Length) {
                //READ A BYTE(INT) FROM THE FILE AND CONVERT TO BYTE
                byte currentByte = (byte)infile.ReadByte();

                //WRITE THE BYTE TO CONSOLE CAST AS CHAR
                Console.Write(currentByte + " ");
                count++;
            }//end while

            //CLOSE THE FILE
            infile.Close();

            Console.WriteLine("\n\n" + count);
        }//end function

        static void SpeechText() {
            //GRAB THE FILE TO BE READ USING A FILESTREAM OBJECT
            FileStream file = new FileStream("C:\\Users\\jonat\\Documents\\WORK\\C# 3Month Lesson Plan\\Week 10\\speech.txt", FileMode.Open);

            //CREATE A COUNTING VARIABLE TO TRACK THE NUMBER OF BYTES COUNTED
            int count = 0;

            //USE A LOOP TO ITERATE THROUGH ALL BYTES OF FILE
            while (file.Position < file.Length) {
                //READ A BYTE FROM FILE AND CAST IT AS A BYTE - STORE TO 'data'
                byte data = (byte)file.ReadByte();

                //WRITE THE BYTE TO THE CONSOLE BY CASTING IT AS A CHAR
                Console.Write((char)data);

                //INCREASE THE BYTE COUNTER BY 1
                count++;
            }//end loop

            //CLOSE THE FILE
            file.Close();

            //DISPLAY THE BYTE COUNT
            Console.WriteLine("\n\n" + count);
        }//end function

        #endregion

        #region ARRAYS (CREATION AND USAGE)

        #region TIC TAC TOE
        static void TicTacToeALaJonathan() {
            Console.WriteLine(" ___ _____ _ ____    ____   ___    ____ ___ __  __ ____  _     _____ ");
            Console.WriteLine("|_ _|_   _( ) ___|  / ___| / _ \\  / ___|_ _|  \\/  |  _ \\| |   | ____|");
            Console.WriteLine(" | |  | | |/\\___ \\  \\___ \\| | | | \\___ \\| || |\\/| | |_) | |   |  _|  ");
            Console.WriteLine(" | |  | |    ___) |  ___) | |_| |  ___) | || |  | |  __/| |___| |___ ");
            Console.WriteLine("|___| |_|   |____/  |____/ \\___/  |____/___|_|  |_|_|   |_____|_____|");
            //INITIALIZE THE GAME (CREATE PLAYER DATA AND BOARD)
            string[] markers = {"X", "O"};
            string[] players = new string[2];
            ConsoleColor[] colors = {ConsoleColor.Red, ConsoleColor.Blue};
            string[,] board = new string[3,3];
            bool playAgain = true; //PLAYAGAIN WILL HANDLE END OF GAME REPLAYS IF DESIRED BY PLAYERS
            Console.WriteLine("\n\nPRESS ANY KEY TO START");
            Console.ReadKey();
            while (playAgain) {      
                Console.Clear();
                //CREATE WIN TRACKING VARIABLE :: -1 - continue :: 1 - win :: 2 - tie
                int winState = -1;
                bool gameOver = false;  //HANDLES INDIVIDUAL GAME STATE
                int turn = 0;           //THIS HANDLES THE TURN ORDER                
                players[0] = Prompt("What is the name of player 1?  ");
                players[1] = Prompt("What is the name of player 2?  ");

                //SET BOARD TO IT'S INITIAL VALUE BEFORE GAME BEGINS
                SetBoard(board);

                while (!gameOver) {
                    //SIMPLIFY TURN INDEX
                    int turnIndex = turn % 2 ;

                    //CLEAR THE CONSOLE OF ALL PREVIOUS VIEW DATA
                    Console.Clear();

                    //CHECK FOR WIN CONDITION OR TIE
                    winState = WinCheck(board, markers[Math.Abs(turn - 1) % 2]);

                    //DRAW THE CURRENT STATE OF THE BOARD
                    DrawBoard(board);

                    //SKIP MAIN GAME LOOP IF WINSTATE != -1
                    if (winState != -1) {
                        gameOver = true;
                    } else {
                        //VARIABLES
                        bool isValid = true;
                        int chosenX = -1;
                        int chosenY = -1;

                        //REQUEST MARKER PLACEMENT
                        do {
                            chosenX = PromptInt($"{players[turnIndex]}: Into which column are you placing your '{markers[turnIndex]}'?  ");
                            chosenY = PromptInt($"Into which row are you placing your '{markers[turnIndex]}'?  ");
                        //VERIFY MARKER PLACEMENT
                            if (chosenX < 1 || chosenX > 3 || chosenY < 1 || chosenY > 3 || board[chosenX - 1,chosenY - 1] != "*") {
                                isValid = false;
                                Console.WriteLine("Your entry was invalid.");
                            } else {
                                isValid = true;
                            }
                        } while (!isValid);

                        //PLACE MARKER
                        PlaceMarker(board, markers[turnIndex], chosenX - 1, chosenY - 1);

                        //UPDATE TURN
                        turn++;

                    }//end if

                }//end main game loop
                if (winState == 1) {
                    Console.WriteLine($"Congratulations {players[Math.Abs(turn - 1) % 2]}\nYOU WIN!");
                } else {
                    Console.WriteLine($"It appears to be a tie.");
                }//end if
                Console.WriteLine("\nPlay again? (y/n)");
                playAgain = Console.ReadKey(true).KeyChar == 'y';
            }//end replay loop
            
        }//end function

        static void SetBoard(string[,] b) {
            //THIS FUNCTION WILL SET ALL OF MY BOARD LOCATIONS TO THEIR STARTING VALUES '*'
            //I HAVE NAMED THE INCOMING BOARD ARRAY 'b' FOR BREVITY
            for (int y = 0; y < b.GetLength(1); y++) {
                for (int x = 0; x < b.GetLength(0); x++) {

                    b[x,y] = "*";

                }//end x
            }//end y
        }//end function

        static void DrawBoard(string[,] b) {
            //THIS FUNCTION WILL SET ALL OF MY BOARD LOCATIONS TO THEIR STARTING VALUES '*'
            //I HAVE NAMED THE INCOMING BOARD ARRAY 'b' FOR BREVITY
            for (int y = 0; y < b.GetLength(1); y++) {
                for (int x = 0; x < b.GetLength(0); x++) {

                    Console.Write(b[x,y]);

                }//end x
                Console.WriteLine();
            }//end y
            Console.WriteLine();
        }//end function

        static int WinCheck(string[,] b, string mark) {
            //CREATE VARIABLES TO INDICATE GAME STATE
            int winState = -1;            
            bool gameEnd = false; //IF gameEnd BECOMES TRUE, ALL FUTURE CHECKS ARE SKIPPED

            //CHECK EACH ROW FOR WIN
            for (int i = 0; i < 3 && !gameEnd; i++) {
                gameEnd = ScanRow(b, mark, i);
            }//end row check

            //CHECK EACH COLUMN FOR WIN
            for (int i = 0; i < 3 && !gameEnd; i++) {
                gameEnd = ScanCol(b, mark, i);
            }//end col check

            //CHECK BOTH DIAGONALS
            if (!gameEnd) {
                if (b[0, 0] == mark && b[1, 1] == mark && b[2, 2] == mark) {
                    gameEnd = true;
                }//end if
                if (b[0, 2] == mark && b[1, 1] == mark && b[2, 0] == mark) {
                    gameEnd = true;
                }//end if
            }//end if

            if (gameEnd) {
                return 1;
            }//end if

            //CHECK IF ANY SPACES ARE STILL AVAILABLE
            for (int y = 0; y < b.GetLength(1); y++) {
                for (int x = 0; x < b.GetLength(0); x++) {
                    //IF A SPACE IS FOUND TO BE AVAILABLE, EARLY OUT
                    if (b[x,y] == "*") {                        
                        return -1;
                    }//end if
                }//end x
            }//end y

            //NO WIN OR AVAILABLE SPACES DETECTED
            return 2; //tie
        }//end function

        static void PlaceMarker(string[,] b, string mark, int x, int y) {
            b[x,y] = mark;
        }//end function

        static bool ScanRow(string[,] b, string mark, int row) {
            return b[0, row] == mark && b[1, row] == mark && b[2, row] == mark;
        }//end function
        static bool ScanCol(string[,] b, string mark, int col) {
            return b[col, 0] == mark && b[col, 1] == mark && b[col, 2] == mark;
        }//end function

        #endregion

        static char[,] SetArray() { ////THIS FUNCTION WILL CREATE A 2D CHAR ARRAY 
                                    ////FILL IT AND RETURN IT TO THE CALLER FUNCTION
            //CREATE EMPTY 2D ARRAY
                char[,] characters = new char[5,5];

            //ACCESS EACH LOCATION OF THE ARRAY USING A NESTED LOOP
                for (int y = 0; y < characters.GetLength(1); y++) {
                    for (int x = 0; x < characters.GetLength(0); x++) {
                        
                    //FILL THE ARRAY WITH THE DESIRED DATA
                        characters[x,y] = '+';
                    }//end x
                }//end y
                
            //RETURN THE ARRAY OUT TO THE CALLER FUNCTION
                return characters;
        }//end function
       
        static void GetArray(int[,] array) { ////THIS FUNCTION WILL DISPLAY  
                                    ////ALL VALUES FROM A GIVEN ARRAY

            //ACCESS EACH LOCATION OF THE ARRAY USING A NESTED LOOP
                for (int y = 0; y < array.GetLength(1); y++) {
                    for (int x = 0; x < array.GetLength(0); x++) {
                        
                    //READ EACH LOCATION FROM THE GIVEN ARRAY
                        Console.Write(array[x,y]);
                    }//end x
                }//end y                
        }//end function

        static void ModeDetector(int[] array) {
            //THIS FUNCTION TAKES AN ARRAY AND DETERMINES WHICH VALUE APPEARS THE MOST FREQUENTLY

            for (int i = 0; i < array.Length; i++) {
                Console.Write(array[i] + " ");
            }//end for

            int[] test = UniqueValues(array);
            int[] final = new int[test.Length];
            int index = 0;
            for (int r = 0; r < test.Length; r++) {
                int incidence = 0;
                for (int i = 0; i < array.Length; i++) {
                    if (test[r] == array[i]) {
                        incidence++;
                    }//end if
                }//end for
                final[index++] = incidence;
            }//end for

            int high = 0;
            for (int i = 0; i < final.Length; i++) {
                if (final[i] > high) {
                    high = i;
                }//end if
            }//end for
            
            Console.WriteLine($"\n\nThe mode is: {test[high]} which occurred {final[high]} times");
        }//end function

        static int[] UniqueValues(int[] array) {    
            int[] roughUniques = new int[array.Length];
            int index = 0;
            for (int i = 0; i < array.Length; i++) {
                bool isRepeat = false;
                for (int u = 0; u < i; u++) {
                    if (array[i] == array[u]) {
                        isRepeat = true;
                    }//end if
                }//end interior scan
                if (!isRepeat) {
                    roughUniques[index++] = array[i];
                }//end if
            }//end for
            int[] final = RemoveZeros(roughUniques);
            return final;
        }//end function

        static int[] RepeatValues(int[] array) {
            int[] roughRepeats = null;
            int index = 0;
            for (int i = 0; i < array.Length; i++) {
                bool isRepeat = false;
                for (int u = i; u < array.Length; u++) {
                    if (array[i] == array[u]) {
                        isRepeat = true;
                    }//end if
                }//end interior scan
                if (isRepeat) {
                    bool isRepeatRough = false;                    
                    if (roughRepeats != null) {
                        for (int r = 0; r < roughRepeats.Length; r++) {
                            if (roughRepeats[r] == array[i]) {
                                isRepeatRough = true;
                            }//end if
                        }//end for
                        if (!isRepeatRough) {
                            roughRepeats[index++] = array[i];
                        }//end if
                    } else {
                        roughRepeats = new int[] {array[i]};
                    }//end if
                }//end if
            }//end for
            int[] final = RemoveZeros(roughRepeats);
            return final;
        }//end function

        static int[] RemoveZeros(int[] array) {
            int index = 0;
            for (int i = 0; i < array.Length; i++) {
                if (array[i] != 0) {
                    index++;
                }//end if
            }//end for
            int[] final = new int[index];
            index = 0;
            for (int i = 0; i < array.Length; i++) {
                if (array[i] != 0) {
                    final[index++] = array[i];
                }//end if
            }//end for
            return final;
        }//end function

        static void MultiDim() {
            //EXAMPLES OF MULTI-DIMENSIONAL ARRAYS

            char[,] ticTacToe = {
                // 0
                {'A', 'B', 'C' } ,
                // 1
                { 'D', 'E', 'F' }, 
                // 2
                {'G', 'H', 'I' }

                };

            Console.WriteLine(ticTacToe[1,0]);

            //EXAMPLE OF ONLY SCANNING 1 DIMENSION
            for (int row = 0; row < ticTacToe.GetLength(0); row++) {                
                Console.Write($"{ticTacToe[row, 0]} ");
            }//end for

            Console.WriteLine();

            //EXAMPLE OF SCANNING BOTH DIMENSIONS
            for (int row = 0; row < ticTacToe.GetLength(0); row++) {                
                for (int col = 0; col < ticTacToe.GetLength(1); col++) {
                    Console.Write($"{ticTacToe[row, col]} ");
                }//end col
                Console.WriteLine();
            }//end row

            char[,] frog = {
                {' ', ' ', '(', ')', '-', '(', ')', ' ', ' ' },
                {'.', '-', '(', '_', '_', '_', ')', '-', '.' },
                {' ' ,'_' ,'<' ,' ' ,' ' ,' ' ,'>' ,'_', ' ' },
                {' ' ,'\\' ,'/' ,' ' ,' ' ,' ' ,'\\' ,'/', ' ' },
            };
            Console.WriteLine();
            for (int y = 0; y < frog.GetLength(0); y++) {
                for (int x = 0; x < frog.GetLength(1); x++) {
                    Console.Write(frog[y,x]);
                }
                Console.WriteLine();
            }//end loop

            Console.WriteLine();

            //EXAMPLE OF CREATING AND FILLING AN EMPTY 2D ARRAY
            int[,] oneToNine = new int[3,3];
            int count = 1;
            for (int y = 0; y < oneToNine.GetLength(1); y++) {
                for (int x = 0; x < oneToNine.GetLength(0); x++) {
                    oneToNine[x, y] = count++;                    
                }//end x 
            }//end y

            for (int y = 0; y < oneToNine.GetLength(1); y++) {
                for (int x = 0; x < oneToNine.GetLength(0); x++) {
                    Console.Write(oneToNine[x, y]);
                }//end x 
                Console.WriteLine();
            }//end y

            //EXAMPLE OF A NON-UNIFORM MULTI-DIMENSIONAL ARRAY
            int[,] nums = {
                //x-0
                {1,3,5,7,9,11},
                //x-1
                {2,4,6,8,10,12 } 
                };
            for (int y = 0; y < nums.GetLength(1); y++) {
                for (int x = 0; x < nums.GetLength(0); x++) {
                    Console.Write(nums[x, y]);
                }
                Console.WriteLine();
            }//end loop


        }//end function

        static void RandomArray() {
            //CREATE A RANDOM OBJECT
            Random rngBot = new Random();
            //CREATE A 2D ARRAY THAT CAN STORE 42 INT VALUES (YOU CHOOSE SIZING)
            int[,] numsArray = new int[10,10];


            ArrayFill(numsArray, rngBot);

            DisplayArray(numsArray);

        }//end function

        static void ArrayFill(int[,] array, Random bot) {
            //FILL THE ARRAY WITH RANDOM NUMBERS BETWEEN 0 - 7
            for (int y = 0; y < array.GetLength(1); y++) {
                for (int x = 0; x < array.GetLength(0); x++) {
                    array[x,y] = bot.Next(8);
                }//end x
            }//end y
        }//end function

        static void DisplayArray(int[,] array) {

            for (int y = 0; y < array.GetLength(1); y++) {
                for (int x = 0; x < array.GetLength(0); x++) {
                    Console.Write($"{array[x,y]} ");
                }//end x
                Console.WriteLine();
            }//end y
        }//end function

        static void ArrayFill(int[,,] array, Random bot) {
            //SET RANDOM VALUES TO A 3 DIMENSIONAL ARRAY

            //FILL THE ARRAY WITH RANDOM NUMBERS BETWEEN 0 - 7
            for (int z = 0; z < array.GetLength(2); z++) {
                for (int y = 0; y < array.GetLength(1); y++) {
                    for (int x = 0; x < array.GetLength(0); x++) {
                        array[x,y,z] = bot.Next(8);
                    }//end x
                }//end y
            }//end z
        }//end function

        static void DiceRollerExample() {

            //DECLARE VARIABLES
            Random robot    = new Random();

            //REQUEST DICE SIDES AND NUMBER OF ROLLS
            int sides       = PromptInt("How many sides does you die have?  ");
            int rollCount   = PromptInt($"How many times should we roll the d{sides}?  ");
            int[] rollOutcomes = new int[rollCount];

            //ROLL ALL OF THE DICE
            for (int i = 0; i < rollOutcomes.Length; i++) {
                rollOutcomes[i] = robot.Next(1, sides + 1);
            }//end for

            //DISPLAY OUTCOME OF DICE ROLLS
            Console.WriteLine("\nROLL OUTCOMES\n----------------");
            for (int i = 0; i < rollOutcomes.Length; i++) {
                //Console.Write(rollOutcomes[i] + " ");
                Console.Write($"{rollOutcomes[i]} ");
            }//end for

        }//end function

        static void DiceRoller() {
            Random rng = new Random();
            int d4 = PromptInt("How many 4 sided dice do you have?  ");
            int d6 = PromptInt("How many 6 sided dice do you have?  ");
            int d8 = PromptInt("How many 8 sided dice do you have?  ");
            int d10 = PromptInt("How many 10 sided dice do you have?  ");
            int d12 = PromptInt("How many 12 sided dice do you have?  ");
            int d20 = PromptInt("How many 20 sided dice do you have?  ");
            int sum = d4 + d6 + d8 + d10 + d12 + d20;

            int[] d4Array  = new int[d4];
            int[] d6Array  = new int[d6];
            int[] d8Array  = new int[d8 ];
            int[] d10Array = new int[d10];
            int[] d12Array = new int[d12];
            int[] d20Array = new int[d20];
            int[] totalArray = new int[sum];

            int index = 0;

            for (int i = 0; i < d4Array.Length; i++) {
                d4Array[i] = rng.Next(1, 5);
                totalArray[index++] = d4Array[i];
            }//end for
            for (int i = 0; i < d6Array.Length; i++) {
                d6Array[i] = rng.Next(1, 7);
                totalArray[index++] = d6Array[i];
            }//end for
            for (int i = 0; i < d8Array.Length; i++) {
                d8Array[i] = rng.Next(1, 9);
                totalArray[index++] = d8Array[i];
            }//end for
            for (int i = 0; i < d10Array.Length; i++) {
                d10Array[i] = rng.Next(1, 11);
                totalArray[index++] = d10Array[i];
            }//end for
            for (int i = 0; i < d12Array.Length; i++) {
                d12Array[i] = rng.Next(1, 13);
                totalArray[index++] = d12Array[i];
            }//end for
            for (int i = 0; i < d20Array.Length; i++) {
                d20Array[i] = rng.Next(1, 21);
                totalArray[index++] = d20Array[i];
            }//end for

            //DISPLAY ROLLS
            Console.WriteLine("\nROLL OUTCOMES\n---------------------------");
            for (int roll = 0; roll < totalArray.Length; roll++) {
                if (roll == d4) {
                    Console.ForegroundColor = ConsoleColor.Green;
                } else if (roll == d4 + d6) {
                    Console.ForegroundColor = ConsoleColor.Blue;
                } else if (roll == d4 + d6 + d8) {
                    Console.ForegroundColor = ConsoleColor.Red;
                } else if (roll == d4 + d6 + d8 + d10) {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                } else if (roll == d4 + d6 + d8 + d10 + d12) {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                Console.Write(totalArray[roll] + " ");
            }//end for
            Console.ResetColor();
        }//end function

        static void ArrayReviewI() {

            //DECLARE VARIABLES
            //string[] groupNames = new string[12];
            string[] groupNames = {"JONATHAN", "ADRIE", "BRYAN", "SAM", "NICOLE", "SARA", "RJ", "CHEL", "SCOTT", "CLYDE", "JELLO", "BRNADON" };

            //GATHER GROUP NAMES
            /*
            for (int person = 0; person < groupNames.Length; person++) {
                groupNames[person] = Prompt("Who just walked in?  ");
            }//end for
            */

            //DISPLAY GROUP NAMES
            Console.WriteLine("\nROLL CALL\n--------------------------");
            for (int person = 0; person < groupNames.Length; person++) {
                Console.WriteLine(groupNames[person]);
            }//end for

        }//end function

        static void ArrayReviewII() {
            
            //PARALLEL ARRAYS
            //Pokemon -- hp -- atk -- type
            string[] pokeNames  = {"Squirtle", "Bulbasaur", "Charmander", "Pikachu ", "Gastly  "};
            int[] hpArray       = new int[pokeNames.Length];
            int[] atkArray      = new int[pokeNames.Length]; 
            string[] typeArray  = {"Water", "Grass", "Fire", "Electric", "Ghost"};

            //GATHER POKEMON DATA
            for (int p = 0; p < pokeNames.Length; p++) {
                hpArray[p] = PromptInt($"What is {pokeNames[p]}'s hp?  ");
                atkArray[p] = PromptInt($"What is {pokeNames[p]}'s atk?  ");
            }//end for            

            //DISPLAY
            Console.WriteLine("\nNAME       \tHP\tATK\tTYPE\n---------------------------------------------------");
            for (int p = 0; p < pokeNames.Length; p++) {
                Console.WriteLine($"{pokeNames[p]}\t{hpArray[p]}\t{atkArray[p]}\t{typeArray[p]}");
            }//end for

        }//end function

        static void PracticeArrays() {
            //CREATING PARALLEL ARRAYS AND SHOWING THEIR RELATIONSHIPS TO EACH OTHER

            #region EXAMPLE 1
            double[] temperaturesC = {20, 19.8, 21.2, 22.1, 20.7, 21};
            double[] temperaturesF = new double[temperaturesC.Length];

            for (int i = 0; i < temperaturesF.Length; i++) {
                temperaturesF[i] = Math.Round(C2F(temperaturesC[i]), 2);
            }//end for
            
            Console.WriteLine("TempF\tTempC\n___________________________");

            for (int i = 0; i < temperaturesF.Length; i++) {
                Console.WriteLine($"{temperaturesF[i]}F\t{temperaturesC[i]}C");
            }//end for
            
            #endregion

            #region EXAMPLE 2
            
            string[] groceries = {"Tortilla Chips", "Pinto Beans", "Onions", "Bananas", "Garlic", "Soy Milk"};
            double[] grocPrices = new double[groceries.Length];

            for (int i = 0; i < groceries.Length; i++) {
                grocPrices[i] = PromptDouble($"Please enter the price of {groceries[i]}?:  ");
            }//end for

            Console.WriteLine("\nGROCERY ITEM PRICES\n--------------------");
            for (int i = 0; i < grocPrices.Length; i++) {
                Console.WriteLine($"{groceries[i]} costs {grocPrices[i]}");
            }//end for
            #endregion


            #region EXAMPLE 3   

            string[] animals    = new string[7];
            string[] sounds     = new string[animals.Length];
            string text         = "";
            int score           = 0;

            for (int i = 0; i < animals.Length; i++) {
                animals[i] = Prompt("Enter the name of an animal:  ");
                sounds[i] = Prompt($"Enter the sound that {animals[i]} makes:   ");                
            }//end for
            Console.Clear();
            Console.WriteLine("ANIMAL NOISES GUESSING GAME");
            for (int i = 0; i < animals.Length; i++) {
                string answer = Prompt($"What animal makes the '{sounds[i]}' sound?  ");
                answer = answer.ToLower();
                if (answer == animals[i].ToLower()) {
                    FlairText("Correct!\n");
                    score++;
                } else {
                    Console.WriteLine($"INCORRECT: The answer was {animals[i]}");
                }//end if
            }//end for

            Console.WriteLine($"You got {score} out of {animals.Length}");
            #endregion

            #region EXAMPLE 4

            animals         = new string[7];
            string[] numbers = {"first", "second", "third", "fourth", "fifth", "sixth", "seventh"};
            bool[] alreadyGuessed = new bool[animals.Length];
            score           = 0;
                       
            for (int i = 0; i < animals.Length; i++) {
                animals[i] = Prompt("Enter the name of an animal:  ");              
            }//end for
            Console.Clear();
            Console.WriteLine("WHAT ANIMALS DID I THINK OF GUESSING GAME");
            for (int guess = 0; guess < animals.Length; guess++) {
                bool isIncorrect = true;
                string answer = Prompt($"What is your {numbers[guess]} guess?  ");
                answer = answer.ToLower();
                
                for (int chk = 0; chk < animals.Length; chk++) {
                    if (answer == animals[chk].ToLower() && alreadyGuessed[chk] != true) {
                        FlairText("Correct!\n");
                        score++;        
                        alreadyGuessed[chk] = true;
                        isIncorrect = false;
                    }//end if 
                }//end for
                if (isIncorrect) {
                    Console.WriteLine("Your guess was incorrect. That animal is not on the list");
                }//end if
            }//end for

            Console.WriteLine($"You got {score} out of {animals.Length}");
            Console.WriteLine("The animals on the list were: ");

            for (int i = 0; i < animals.Length; i++) {
                Console.WriteLine(animals[i]);
            }//end for

            #endregion
        }//end function

        static void FlairText(string text) {
            //CREATING AN ARRAY TO STORE COLORS
            ConsoleColor[] colors = {ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.White, ConsoleColor.Blue, ConsoleColor.Gray, ConsoleColor.Magenta, ConsoleColor.Red, ConsoleColor.Yellow};
            //11 colors
            for (int l = 0; l < text.Length; l++) {
                Console.ForegroundColor = colors[l % colors.Length];
                Console.Write(text[l]);
            }//end for
            Console.WriteLine();
        }//end function

        static void Selections() {
            //DISPLAY HOW SELECTION STRUCTURES WORK

            //ifelse
            //switch
            //ternary
            //bools
            //comparison operators            

            //  > >= == != < <= --- produce a True or False response

            // 7 > 3 -- TRUE
            // 3 > 5 -- FALSE
            // "Jim" == "Jim" -- TRUE
            // "Jim" == "jim" -- FALSE
            // "text" != "test" --TRUE
            // "lol" > < >= <= "oops"
            
            int age = 0;
            bool is21 = false;

            age = PromptInt("enter age: ");  // 4

            is21 = age >= 21;

            //SHOW HOW TO CREATE AN INPUT VALIDATION LOOP (ONLY ALLOWED FORWARD IF 21 OR OLDER)
            while (age < 21) {
                Console.WriteLine($"You are {age} years old");
                Console.WriteLine("Another year passes");
                age++;
            }//end while

            #region EXAMPLE OF AN IF/ELSE SELECTION TREE            
            if(age < 55 && age >= 21 ) {
                //run CODE BLOCK A -- Congrats You're about to be a senior
                //200 lines of code
            } else if (age < 21) {
                //run CODE BLOCK B // Can't drink yet
            } else if (age < 10) {
                //run CODE BLOCK C -- You're not in the double digits yet
            } else {
                //run CODE BLOCK D
            }//end if
            #endregion

            #region EXAMPLE OF A SWITCH SELECTION STRUCTURE

            switch(age) {
                case 10:
                    //RUN 10 YEAR OLD CODE
                    //code block
                    break;
                case 21:
                    //RUN 21 YEAR OLD CODE
                    //first drink's on me
                    break;
                case < 55: 
                    //RUN YOUNGER THAN 55 CODE
                    // Youngster
                    break;
            }//end switch                       
            #endregion

        }//end function

        static void Arrays() {
            //CREATE AN ARRAY USING LITERAL VALUES
            string[] daysArray = {"Mon", "Tues", "Wed", "Thu", "Fri", "Sat", "Sun"};

            //READ VALUE FROM AN ARRAY
            Console.WriteLine($"daysArray[2] is {daysArray[2]}");  //Outputs - daysArray[2] is Wed

            //SET VALUE TO AN ARRAY ELEMENT AT THE SPECIFIED INDEX
            daysArray[1] = "Taco Tuesday";  //Now the array holds these values -> {Mon, Taco Tuesday, Wed, Thu, Fri, Sat, Sun}
            

            //CREATE AN ARRAY WITH SPECIFIED NUMBER OF ELEMENTS
            double[] dailyPay = new double[5];  // THIS ARRAY NOW HAS SPACE FOR 5 ELEMENTS OF TYPE 'DOUBLE'

            //SET VALUE TO AN ARRAY ELEMENT AT SPECIFIED INDEX
            dailyPay[0] = 33.60;  
            dailyPay[1] = 44.40;
            dailyPay[2] = 34.30;
            dailyPay[3] = 42.40;
            dailyPay[4] = 43.42;
            
            //READ VALUE FROM AN ARRAY
            double dayPay = dailyPay[1];  // THE VALUE IN dailyPay AT INDEX 1 IS STORED INTO dayPay;

            Console.WriteLine(dayPay); // Outputs - 44.40

        }//end function

        static void AnnoyTheCodersExe() {
            //THIS IS A POINTLESS PROGRAM THAT ONLY EXISTS TO BEEP AND ANNOY THE CODERS
            
            while (true) {
                Random random = new Random();
                int beepCount = random.Next(30);

                for (int i = 0; i < beepCount; i++) {
                    Console.Beep();                    
                }//end for                
                Thread.Sleep(60000);
            }//end while
        }//end function

        static void NameSorter() {
            //SORT NAMES BY ALPHABETICAL VALUE OF FIRST CHARACTER
            //SHOW HOW EACH CHAR HAS AN ASCII VALUE AND CAN BE COMPARED

            //VARIABLES
            string fName = "{";
            string lName = " ";
            string input = "";

            while (input != "???") {
                
                input = Prompt("Please enter a name:  ");
                
                
                if (input != "???") {
                
                    if (input[0] < fName[0]) {

                        fName = input;

                    }//end if
                    if (input[0] > lName[0]) {

                        lName = input;

                    }//end if
                }//end if
            }//end while
            Console.WriteLine($"Earliest Name = {fName} -- Latest Name = {lName}");
        }//end function

        static void StringIndex() {
            //ILLUSTRATE THE ARRAY PROPERTIES OF A STRING

            //DECLARE VARIABLES
            string sentence = "The small boy jumped over the stream.";
            
            //SHOW HOW WE CAN PLUCK A CHAR OUT OF A STRING BY USING ITS INDEX
            char firstLetter = sentence[0];                       
            Console.WriteLine(firstLetter);

            //WRITE EACH CHARACTER FROM THE EXAMPLE SENTENCE TO THE CONSOLE INDIVIDUALLY
            for (int index = 0; index < sentence.Length; index++) {

                char character = sentence[index];

                Console.Write(character);
            }//end for            
        }//end function       

        #endregion

        #region SMALL IN-CONSOLE 'GAME'
        static void CharController() {

            //VARIABLES
            int x = 0;
            int y = 1;
            int deathX = 15;
            int deathY = 25;
            int gameX = 45;
            int gameY = 7;
            bool gameOver = false;
            bool isALoser = false;
            int maxWid = 0;
            int maxHei = 0;
            Random rng = new Random();
            int battleCounter = rng.Next(10, 31);

            while (!gameOver) {
                bool entryValid = true;
                string smiley = isALoser ? ":(" : ":)";

                //COLLECT THE CONSOLE WINDOW'S WIDTH AND HEIGHT
                maxWid = Console.WindowWidth;
                maxHei = Console.WindowHeight;

                //CLEAR PREVIOUSLY STORED CONSOLE TEXT/VALUES
                Console.Clear();
                Console.CursorVisible = false;

                //INTRODUCE CONCEPT TO PLAYER
                Console.WriteLine($"WELCOME TO MY LITTLE SMILEY CONTROLLER \t\t Battle- {battleCounter} steps away.");                
                

                //CREATE DEATH LOCATION
                Console.SetCursorPosition(deathX, deathY);
                Console.Write("DEATH HERE");

                //CREATE GUESSING GAME LOCATION
                BuildingMaker(gameX, gameY);

                //UPDATE CURSOR POSITION AND PREPARE TO WRITE CHARACTER TO SCREEN
                Console.SetCursorPosition(x, y);

                //WRITE CHARACTER TO SCREEN
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(smiley);
                Console.ResetColor();

                //GATHER NEW KEYPRESS INFORMATION
                char enteredKey = Console.ReadKey(true).KeyChar;

                //PARSE KEYPRESS INFORMATION INTO MOVEMENT INFORMATION
                if (enteredKey == 'w' && (y - 1) > 1) {
                    y -= 1;
                } else if (enteredKey == 'a' && (x - 2) > 0) {
                    x -= 2;
                } else if (enteredKey == 's' && (y + 1) < maxHei) {
                    y += 1;
                } else if (enteredKey == 'd' && (x + 2) < maxWid) {
                    x += 2;
                } else if (enteredKey == 'W' && (y - 3) > 1) {
                    y -= 3;
                } else if (enteredKey == 'A' && (x - 5) > 0) {
                    x -= 5;
                } else if (enteredKey == 'S' && (y + 3) < maxHei) {
                    y += 3;
                } else if (enteredKey == 'D' && (x + 5) < maxWid) {
                    x += 5;
                } else if (enteredKey == ' ') {
                    if (Math.Abs(x - deathX) < 6 && Math.Abs(y - deathY) < 3) {
                        gameOver = true;
                    } else if (Math.Abs(x - gameX) < 6 && Math.Abs(y - gameY) < 3) {
                        isALoser = GuessANum();
                        battleCounter = rng.Next(10, 31);
                    }//end if
                } else {
                    entryValid = false;
                }//end moevement controls
                battleCounter = entryValid ? battleCounter - 1 : battleCounter;

                if (battleCounter <= 0) {                    
                    isALoser = !BattleSystem();
                    battleCounter = rng.Next(10, 31);
                }//end if
            }//end loop
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("YOU ARE DEAD");

            static void BuildingMaker(int bldX, int bldY) {
                //FUNCTION WRITES AN ASCII BUILDING IMAGE TO THE CONSOLE
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(bldX - 5, bldY);
                Console.Write("|___| |___|");
                Console.SetCursorPosition(bldX - 5, bldY - 1);
                Console.Write("|   /-\\   |");
                Console.SetCursorPosition(bldX - 5, bldY - 2);
                Console.Write("|         |");
                Console.SetCursorPosition(bldX - 6, bldY - 3);
                Console.Write("GUESSING GAME");           
                Console.SetCursorPosition(bldX - 5, bldY - 4);
                Console.Write("/         \\");
                Console.SetCursorPosition(bldX - 5, bldY - 5);
                Console.Write(" _________");
                Console.ResetColor();
            }//end local function

            static bool GuessANum() {
                //GAME WHERE PLAYER GUESSES A NUMBER

                Console.Clear();
                Random rng = new Random();
                int correctNum = rng.Next(21);
                bool winner = false;

                Console.WriteLine("Guess a number between 0 - 20.");
                for (int i = 3; i > 0; i--) {
                    int guess = PromptInt($"You have {i} guesses:  ");
                
                    if (guess == correctNum) {
                        i = 0;
                        winner = true;
                    } else if (guess < correctNum) {
                        Console.WriteLine("Too low!");
                    } else {
                        Console.WriteLine("Too high!");
                    }//end if
                }
                if (winner) {
                    Console.WriteLine("YOU WIN!!! CONGRATS!");
                } else {
                    Console.WriteLine("YOU LOOOOOOOSE!!!! YOU ARE A LOOOOOOOOSER!!!");
                }
                Console.ReadKey(true);
                return !winner;
            }//end local function

            static bool BattleSystem() {
                Console.Clear();

                Random rng = new Random();

                int foeHp = 25;
                int foeAcc = 80;
                int foeStr = 6;
                int plrHp = foeHp;
                int plrAcc = 90;
                int plrStr = 8;
                bool plyrTurn = true;
                bool plyrWin = false;
                bool gameOver = false;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("YOU ARE IN BATTLE\n");    
                Thread.Sleep(1600);
                Console.Clear();

                while (!gameOver) {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("YOU ARE IN BATTLE\n");                
                    while (Console.KeyAvailable) {
                        Console.ReadKey(true);
                    }//end while
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"\nPlayer HP - {plrHp}/25");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Enemy HP  - {foeHp}/25\n\n");
                    Console.ResetColor();
                    if (plyrTurn) {
                        bool dumbPlayer = true;
                        string entry = "";
                        int playerAssCount = 0;
                        Console.WriteLine("You face your opponent.");
                        Console.WriteLine("\tWhat would you like to do?");
                        Console.WriteLine("\tA. Attack\tB. Attack\n\tC. Attack\tD. ...duh\n\n");
                        entry = Convert.ToString(Console.ReadKey(true).KeyChar);
                        entry = entry.ToLower();
                        dumbPlayer = !(entry[0] == 'a' || entry[0] == 'b' || entry[0] == 'c' || entry[0] == 'd');
                        while (dumbPlayer && playerAssCount < 5) {
                            entry = Convert.ToString(Console.ReadKey(true).KeyChar);
                            entry = entry.ToLower(); 
                            dumbPlayer = !(entry[0] == 'a' || entry[0] == 'b' || entry[0] == 'c' || entry[0] == 'd');
                            playerAssCount++;
                        }//end while
                        Console.WriteLine("...");
                        Thread.Sleep(1000);
                        if (playerAssCount > 4) {
                            Console.Write("Stop fucking around... ");
                            Thread.Sleep(1200);
                            Console.WriteLine("You lose a turn.");
                        } else if (entry == "d") {
                            Console.Write("You notice your shoe is untied... ");
                            Thread.Sleep(1000);
                            Console.WriteLine("Not sure why you didn't just attack.");
                        } else {
                            int damage = Attack(plrStr, plrAcc);
                            Console.WriteLine("You swing at your opponent and...");
                            Thread.Sleep(1300);
                            if (damage == 0) {
                                Console.WriteLine("Your attack MISSED!");
                            } else {
                                foeHp -= damage;
                                Console.WriteLine($"You hit your opponent for {damage} damage!");
                            }//end if
                            plyrWin = CheckDeath(foeHp);
                            gameOver = plyrWin;
                        }//end if
                    } else {
                        Console.WriteLine("Your opponent prepares themself.");
                        Console.WriteLine("...");
                        Thread.Sleep(2000);
                        int critFail = rng.Next(6);
                        if (critFail == 5) {
                            Console.WriteLine("Your opponent is distracted by the ARCADE in the back of the room.");
                        } else {
                            int damage = Attack(foeStr, foeAcc);
                            Console.WriteLine("Your opponent lunges at you and...");
                            Thread.Sleep(1300);
                            if (damage == 0) {
                                Console.WriteLine("They MISS!");
                            } else {
                                plrHp -= damage;
                                Console.WriteLine($"Your opponent hits you for {damage} damage!");
                            }//end if
                            gameOver = CheckDeath(plrHp);
                        }//end if
                    }//end if
                    Thread.Sleep(1000);
                    Console.WriteLine("\n\nPress any letter to continue.");
                    Console.ReadKey(true);
                    Console.Clear();
                    plyrTurn = !plyrTurn;
                }//end while
                if (plyrWin) {
                    Console.Write("\n\n\nYou have defeated your opponent...");
                    Thread.Sleep(1200);
                    Console.WriteLine(" for now.");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n\t\tYOU WIN!!\n\n");
                    Console.ResetColor();

                } else {
                    Console.WriteLine("\n\n\nYou begin to pass out, and as your consciousness fades, you realize....");
                    Thread.Sleep(1500);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n\t\tYOU'RE A LOSER\n\n");
                    Console.ResetColor();
                }//end if
                Thread.Sleep(500);
                Console.WriteLine("Press any letter to exit.");
                Console.ReadKey(true);
                Console.Clear();
                return plyrWin;

                int Attack (int sourceStr, int sourceAcc) {
                    int hit = rng.Next(100);
                    int damage = 0;
                    if (hit <= sourceAcc) {
                        damage = rng.Next(1, 9);
                        damage += sourceStr;
                    }//end if
                    return damage;
                }//end innerfunction

                bool CheckDeath(int targetHp) {
                    return targetHp <= 0;
                }//end innerfunction

            }//end local function
        }//end game function

        #endregion

        #region LOOPS
        static void TimeTracker() {
            //CREATE STORAGE VARIABLE
            int minutes = PromptInt("How many minutes do you want to track?  ");
            int elapsedSeconds = 0;

            //CREATE LARGER LOOP
            for (int min = 0; min < minutes; min++) {

                //CREATE SMALLER LOOP
                for (int sec = 0; sec < 60; sec++) {

                    //DISPLAY SECONDS TO SCREEN
                    Console.Write($"{sec} ");

                    elapsedSeconds++;

                }//end for

                //DISPLAY MINUTES TO SCREEN
                Console.WriteLine($"\n{min + 1} minutes");

            }//end for

            Console.WriteLine($"ELAPSED TIME: {minutes} minutes : {elapsedSeconds} seconds");

        }//end function

        static void KeyCharDetection() {
            //ILLUSTRATE HOW THE Console.ReadKey METHOD WORKS
            //VARIABLE
            bool isWPressed = false;

            //BEGIN LOOP (IT RUNS AS LONG AS isWPressed IS FALSE
            while (isWPressed != true) {

                Console.WriteLine("Press a key: (If you press 'W' I will die)");
                
                //RECEIVE THE NEXT PRESSED KEY INTO 'SYMBOL'
                char symbol = Console.ReadKey(true).KeyChar;                
                
                ////THESE ARE 2 DIFFERENT WAYS TO EVALUATE THE KEY PRESS TO UPDATE OUR BOOL
                // FIRST WAY
                /*  
                if (symbol == 'w' || symbol == 'W') {
                    isWPressed = true;
                }//end if
                */

                //SECOND WAY
                isWPressed = symbol == 'w' || symbol == 'W';

            }//end while
            Console.WriteLine("I am literally dead");
        }//end function

        static void Random() {
            //THIS PROGRAM ILLUSTRATES THE A USAGE OF THE RANDOM OBJECT AND HOW IT CAN BE USED TO WRITE RANDOM INFO TO CONSOLE

            //DECLARE VARIABLES
            //INSTANTIATE A RANDOM OBJECT
            Random rng = new Random();

            while(true) {
                //LOCAL VARIABLES
                int randomNumber = 0;

                //PAUSE FOR 200ms
                Thread.Sleep(200);
              
                randomNumber = rng.Next(20, 128);

                //CONVERT NUMBER TO TEXT CHARACTER (CHAR)
                char text = Convert.ToChar(randomNumber);

                //WRITE TO TEH SCREEN
                Console.Write(text);
            }//end while

        }//end function

        static void ForLoops(int iterations) {
            //EXAMPLE OF PUTTING SELECTION STRUCTURE INTO A LOOP

            for (int i = 0; i < iterations; i++) {
                if (i % 2 == 0) {
                    Bottles();
                } else {
                    RomanNumerals(i);
                }
            }//end for

        }//end function

        static void Bottles() {
            //RUNS A DISPLAY OF THE SONG 99 BOTTLES OF BEER

            //DISPLAY THE TITLE IN FANCY BORDER
            Fancify("99 BOTTLES OF BEER -- EVERYONE SING ALONG!");

            //VARIABLE
            int bottles = 99;

            //PROCESS
            while (bottles > 0) {
                //OUTPUT
                Console.WriteLine($"{bottles} bottles of beer on the wall");

                //ITERATE THE LOOP
                bottles--;
            }//end loop

        }//end function

        static long Factorize(int num) {
            //FIND THE FACTORIAL OF GIVEN NUMBER

            //VARIABLE (LONG BECAUSE FACTORIALS GET BIG QUICKLY
            long factor = num;

            //PROCESS
            while (num != 1) {
                factor = factor * (num - 1);
                num--;
            }//end while
            //OUTPUT
            return factor;
        }//end function
            

        static bool ReverseFactorial(double postFac) {
            //DETERMINE IF THE GIVEN NUMBER IS A FACTORIAL OUTPUT

            //VARIABLE
            int checkNum = 1;
            
            //PROCESS
            while (checkNum <= postFac) {
                postFac /= checkNum;
                //IF DIVIDING THE GIVEN NUMBER BY A CHECK NUMBER (WHOLE NUM) EQUALS 1 THE PRE-FACTORIAL NUMBER HAS BEEN FOUND
                if (postFac == 1) {
                    Console.WriteLine($"{checkNum}!");
                    return true;
                } else {
                    checkNum++;
                }//end if
            }//end while

            //OUTPUT
            return false;
        }//end function

        static int Factorialize(int num) {
            //FIND THE FACTORIAL OF A GIVEN NUMBER

            //VARIABLE
            int factor = 1;

            //PROCESS
            while (num > 0) {
                factor *= num;
                num--;
            }//end while

            //OUTPUT
            return factor;
        }//end function

        static void DrinkCalculator() {
            //PROGRAM THAT CALCULATES THE TOTAL COST OF DRINKS PURCHASED IN AN EVENING
            
            //VARIABLES
            int drinks = 0;
            double drinkSum = 0;
            double tip = 0.0;
            double tax = 0.0;
            double total = 0.0;
            bool isFinished = false;

            Console.WriteLine("DRINK TABULATOR: ");

            //REQUESTING DATA AND PROCESSING
            while (!isFinished) {
                drinkSum += PromptDouble("How much does this drink cost? $");
                drinks++;
                Console.WriteLine("Finished? (y/n)");
                isFinished = Console.ReadKey(true).KeyChar == 'y';
            }//end loop

            //PROCESS
            tip = PromptDouble("How much would you like to tip? $");
            tax = drinkSum * 0.05;
            total = drinkSum + tip + tax;

            //OUTPUT
            Console.WriteLine($"--------------------------\nSUBTOTAL -- {drinkSum:C}\nTIP      -- {tip:C}\nTAX      -- {tax:C}\nTOTAL    -- {total:C}");
        }//end function

        #endregion

        #region FUNCTIONS (BOTH HELPER FUNCTIONS AND SELF-CONTAINED PROGRAM FUNCTIONS)

        #region EXAMPLE OF OVERLOADING (CREATING MULTIPLE VERSIONS OF SAME FUNCTION

        //OVERLOADED FUNCTIONS CAN HAVE DIFFERENT BODY CODE, BUT MUST ALWAYS RETURN THE SAME DATA TYPE
        //NOTICE THE RETURN TYPE OF BOTH ADD FUNCTIONS IS 'DOUBLE'
        static double Add(double number1, double number2) {
            return number1 + number2;
        }//end function

        static double Add(double number1, double number2, double number3) {
            return number1 + number2 + number3;
        }//end function

        #endregion
        static void Fancify(string text) { 
            //CREATE A FANCY BORDER FOR A GIVEN STRING
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine(text);
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
        }//end function

        static double C2F(double cel) {
            //CONVERT CELCIUS (GIVEN) TO FAHRENHEIT
            return (cel * 1.8) + 32;
        }//end function

        static int Add(int num1, int num2) {
            //ADD 2 GIVEN NUMBERS TOGETHER AND RETURN SUM VALUE

            //VARIABLE
            int sum = 0;
            //PROCESS
            sum = num1 + num2;
            //RETURN
            return sum;

        }//end function

        static void KilometerConverter() {
            //SELF-CONTAINED PROGRAM THAT UTILIZES THE KtoM FUNCTION

            //VARIABLES
            double miles = 0.0;
            double kilometers = 0.0;

            //INPUT
            kilometers = PromptDouble("How many kilometers would you like to convert into miles? ");

            //PROCESS
            miles = KtoM(kilometers);

            //OUTPUT
            Console.WriteLine($"{kilometers} kilometers is {miles} miles");
            
        }//end function

        static double KtoM(double kms) {
            //CONVERT KILOMETERS TO MILES

            //VARIABLE
            double mls = 0.0;

            //PROCESS
            mls = kms * 0.6214;

            //OUTPUT / RETURN
            return mls;
        }//end function

        static string SuperSizeMe(string foodItems) {
            //TAKE ANY STRING, AND RETURN IT AFTER ADDING TEXT
            return foodItems + " and a bag full of fries";
        }//end function

        static void RomanNumerals(int number) {                       
            //RECEIVE A NUMBER AS AN ARGUMENT, THEN WRITE THE NUMBER'S ROMAN NUMERAL VERSION TO THE CONSOLE
            if (number == 1) {
                Console.WriteLine("Roman Numeral = 'I'");
            } else if (number == 2) {
                Console.WriteLine("Roman Numeral = 'II'");
            } else if (number == 3) {
                Console.WriteLine("Roman Numeral = 'III'");
            } else if (number == 4) {
                Console.WriteLine("Roman Numeral = 'IV'");
            } else if (number == 5) {
                Console.WriteLine("Roman Numeral = 'V'");
            } else if (number == 6) {
                Console.WriteLine("Roman Numeral = 'VI'");
            } else if (number == 7) {
                Console.WriteLine("Roman Numeral = 'VII'");
            } else if (number == 8) {
                Console.WriteLine("Roman Numeral = 'VIII'");
            } else if (number == 9) {
                Console.WriteLine("Roman Numeral = 'IX'");
            } else if (number == 10) {
                Console.WriteLine("Roman Numeral = 'X'");
            } else {
                Console.WriteLine("ERROR! You must enter a number between 1 - 10");
            }//end if

        }//end function
        #endregion

        #region PROMPT FUNCTIONS


        static string Prompt(string dataRequest) {
            //VARIABLES
            string userInput = "";

            //REQUEST INFORMATION FROM USER
            Console.Write(dataRequest);

            //RECEIVE RESPONSE
            userInput = Console.ReadLine();

            return userInput;
        }//end function


        static int PromptInt(string dataRequest) {
            //VARIABLE
            int userInput = 0;
            bool isValid = false;

            //INPUT VALIDATION LOOP
            do {
                Console.Write(dataRequest);
                isValid = int.TryParse(Console.ReadLine(), out userInput);
            }while (isValid == false);

            return userInput;
        }//end function


        static double PromptDouble(string dataRequest) {
            //VARIABLE
            double userInput = 0;

            //REQUEST AND RECEIVE 
            userInput = double.Parse(Prompt(dataRequest));

            return userInput;
        }//end function

        #endregion

    }//end class (program)

}//end namespace