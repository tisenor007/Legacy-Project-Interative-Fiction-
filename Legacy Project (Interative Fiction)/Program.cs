using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Legacy_Project__Interactive_Fiction_
{
    class Program
    {
        //intializng.....
        static int PageNumber;
        static string line;
        static string[] linesection;
        static bool GameOver;

        //story
        //if you do anything to this to anything, any line integrity check will fail......
        static string[] story = new string[]
        {
            "You are Lebron James walking down the street with a Sprite Cranberry in your pocket, you see a house. What do you do?;Go to House;Keep Walking;1;2",//0
            "Going to the house, which way do you approach it?;Front;Back;3;4",//1
            "If you keep walking you Sprite Cranberry is getting cold. What do you do?;Drink it;Make your way back to the house;5;1",//2
            "Approaching the house from the front makes people see you. What do you do;Hide behind bushes;Keep walking up to house;6;7",//3
            "You get up to the door, what do you do?;Knock on the door;Try to open the door;8;9",//4
            "You pass out. You wake up in a basketball game and your opponent is about to dunk on you. What do you do;Try to steal the ball;Try to stop opponent;10;11",//5
            "Hiding behind bushes makes you well hidden. You see an opening to get to there door, what do you do?;Run to the door before someone sees you;Keep Hiding;4;12",//6
            "Walking up to house and not hiding causes people who live there to see and call the police. What do you do?;Run away;Stay;13;14",//7
            "A person answers the door and ask 'What are you doing here?'. What do you do?;Ask if they want a Sprite Cranberry;Run Away;15;13",//8
            "The door opens and everyone inside panics. What do you do?;Ask if they want a Sprite Cranberry.;Say nothing;15;16",//9
            "Stealing the ball gives you a fast break chance. What do you do?;Do a dirty dunk;Try a three;17;18",//10
            "Trying to stop your opponent fails and your opponent dunks on you and ruins your career.",//11
            "If you keep Hiding the people eventually see you and call the police. When the police arrive you get aressted for trespassing.",//12
            "Running away makes the Sprite Cranberry, this prevents anyone from drinking the Sprite Cranberry.",//13
            "If you stay the police are called and you are arrested for trespassing.",//14
            "Everyone answers 'uhuh'. This makes it so everyone gets a nice cold drink of Sprite Cranberry during the most thirstiest time of the year.",//15
            "Saying nothing makes them call the police. You are arrested for trespassing.",//16
            "Doing a dirty dunk ends your opponets career and you live the rest of your life as a legend.",//17
            "You brick the three and you live the rest of your life as a living meme.",//18


        };

        //story components
        static string currentpage;
        static string optionA;
        static string optionB;
        static string destinationPage1;
        static string destinationPage2;
        

        //main menu
        static void Main()
        {
            //display
            Console.WriteLine();
            Console.WriteLine("THE ANSWER IS CLEAR.....");
            Console.WriteLine("------------------------");
            Console.WriteLine();
            Console.WriteLine("1 - New Game");
            Console.WriteLine("2 - Quit Game");
            Console.WriteLine();
            Console.WriteLine("Press key of option to continue...");
            //Console.WriteLine(story[2]); //Debug code
            while (true)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.D1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Checking story's integrity.....");
                    //willl go to function that will check story with hash codes
                    Hashfunction();


                }

                if (keyPressed.Key == ConsoleKey.D2)
                {
                    //app closes if you quit
                    System.Environment.Exit(1);
                }
                //if you hit anyhing else
                else
                {
                    Console.WriteLine("This is not an option, try again");
                }
            }
            
        }
        //game engine
        static void MiniGameEngine()
        {
            PageNumber = 0;
            //game loop
            while (GameOver == false)
            {
                //every page number will equal a line of the array
                line = story[PageNumber];
                //this will split up each line into line sections
                linesection = line.Split(';');

                //will know when a line is a game over line.. and will break out of game loop...
                if (line == linesection[0])
                {
                    
                    GameOver = true;
                    break;
                }

                //equalizing story components to line sections
                currentpage = linesection[0];
                optionA = linesection[1];
                optionB = linesection[2];
                destinationPage1 = linesection[3];
                destinationPage2 = linesection[4];


                //converting strings to ints
                int Destination1 = int.Parse(destinationPage1);
                int Destination2 = int.Parse(destinationPage2);

                
                //display
                Console.WriteLine();
                Console.WriteLine("======================================================================================================================");
                Console.WriteLine("Page: " + PageNumber);
                Console.WriteLine();
                Console.WriteLine(currentpage);
                Console.WriteLine("A - " + optionA);
                Console.WriteLine("B - " + optionB);
                Console.WriteLine("C - Quit");
                Console.WriteLine("Press key of option to progress....");
                Console.WriteLine();
                Console.WriteLine("======================================================================================================================");

                //was going to put this in but realized hash function took care of this....
               // if (Destination1 < 0)
                //{
                   // Console.WriteLine("Page in story cannot be lower than zero. Please ensure story is correct");
                //}
                //if (Destination2 < 0)
                //{
                   // Console.WriteLine("Page in story cannot be lower than zero. Please ensure story is correct");
                //}

                ConsoleKeyInfo keyPressed = Console.ReadKey();

                //if A is pressed you go to first destination page
                if (keyPressed.Key == ConsoleKey.A)
                {
                    PageNumber = Destination1;
                }
                //if you press B it goes to the sencond....
                if (keyPressed.Key == ConsoleKey.B)
                {
                    PageNumber = Destination2;
                }
               

            }
            while (GameOver == true)
            {
                
                //Game over display
                Console.WriteLine();
                Console.WriteLine("======================================================================================================================");
                Console.WriteLine("Page: " + PageNumber);
                Console.WriteLine();
                Console.WriteLine("THE END!");
                Console.WriteLine();
                Console.WriteLine(story[PageNumber]);
                Console.WriteLine("A - Main Menu");
                Console.WriteLine("B - Quit");
                Console.WriteLine();
                Console.WriteLine("======================================================================================================================");
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                //takes you to main menu
                if (keyPressed.Key == ConsoleKey.A)
                {
                    GameOver = false;
                    Main();
                }
                //quits
                if (keyPressed.Key == ConsoleKey.B)
                {
                    System.Environment.Exit(1);
                }
                //if you just hit something random it will take you to the main menu anyways
                //if you would have wished to exit you can do it from menu
                else
                {
                    GameOver = false;
                    Console.WriteLine("This is not an option....");
                    Console.WriteLine("Taking you back to main menu....");
                    Main();
                }

            }
        }

        //function I used to generate hash codes for each line(page) in the story
        static void GenerateHash() 
        {
            byte[] hashValue;

            //used to convert string into an array of "Unicode bytes"...
            UnicodeEncoding ue = new UnicodeEncoding();

            //put whatever line number in here to get the hash code for it....
             byte[] messageBytes = ue.GetBytes(story[PageNumber]);

            //this creates hash value..
            SHA256 shHash = SHA256.Create();

            //makes hash value from array of bytes..
            hashValue = shHash.ComputeHash(messageBytes);

            //display for hash value..
            foreach (byte b in hashValue)
            {
            Console.Write(" {0} ", b + ",");
            }

        }
        static void Hashfunction()
        {
            //hash value for each line of my story.
            //labeled by line number from 0 - 18
            byte[] SHV0 = { 108, 144, 162, 159, 114, 63, 133, 182, 255, 183, 111, 177, 169, 127, 37, 218, 208, 161, 18, 169, 49, 59, 36, 3, 10, 122, 205, 109, 100, 151, 104, 251 };
            byte[] SHV1 = { 224, 18, 65, 168, 244, 73, 27, 118, 231, 113, 38, 164, 72, 95, 117, 73, 131, 69, 199, 113, 195, 85, 132, 105, 235, 77, 196, 59, 236, 139, 229, 55 };
            byte[] SHV2 = { 222, 69, 153, 68, 167, 126, 63, 206, 53, 217, 52, 84, 164, 214, 26, 217, 71, 184, 97, 129, 30, 171, 140, 116, 203, 200, 169, 141, 68, 242, 156, 110 };
            byte[] SHV3 = { 96, 35, 138, 214, 87, 219, 250, 32, 139, 141, 89, 226, 184, 72, 67, 164, 97, 65, 112, 95, 193, 166, 164, 31, 137, 188, 210, 191, 67, 142, 221, 145 };
            byte[] SHV4 = { 33, 254, 154, 119, 211, 13, 139, 214, 239, 105, 173, 37, 32, 162, 53, 243, 78, 240, 94, 63, 95, 229, 75, 218, 228, 90, 70, 156, 108, 148, 139, 69 };
            byte[] SHV5 = { 110, 26, 144, 109, 187, 230, 224, 239, 219, 127, 125, 120, 231, 105, 41, 15, 250, 139, 146, 1, 54, 201, 176, 209, 116, 137, 28, 51, 199, 121, 167, 237 };
            byte[] SHV6 = { 45, 26, 23, 45, 234, 227, 172, 6, 218, 114, 65, 239, 186, 232, 168, 179, 229, 124, 165, 185, 28, 72, 243, 62, 71, 143, 21, 80, 111, 74, 252, 120 };
            byte[] SHV7 = { 50, 105, 185, 0, 101, 30, 75, 147, 114, 116, 178, 52, 111, 253, 187, 4, 19, 155, 237, 4, 144, 185, 198, 218, 111, 242, 163, 106, 108, 37, 46, 74 };
            byte[] SHV8 = { 64, 253, 184, 248, 153, 26, 240, 21, 186, 245, 65, 202, 210, 42, 73, 137, 189, 208, 255, 86, 43, 160, 114, 149, 218, 105, 185, 156, 142, 162, 249, 93 };
            byte[] SHV9 = { 212, 14, 121, 139, 71, 237, 153, 182, 179, 115, 27, 143, 189, 225, 43, 145, 36, 19, 142, 215, 145, 36, 71, 108, 26, 76, 45, 101, 91, 223, 48, 181 };
            byte[] SHV10 = { 242, 177, 61, 240, 250, 31, 210, 106, 197, 226, 195, 93, 102, 209, 90, 161, 77, 13, 172, 204, 64, 103, 224, 13, 206, 187, 165, 191, 248, 245, 160, 30 };
            byte[] SHV11 = { 26, 16, 168, 139, 178, 67, 231, 59, 98, 197, 137, 224, 155, 110, 52, 122, 0, 146, 119, 215, 136, 63, 83, 41, 66, 207, 204, 144, 171, 211, 167, 243 };
            byte[] SHV12 = { 238, 42, 29, 242, 0, 189, 122, 35, 127, 29, 197, 166, 3, 88, 201, 4, 135, 247, 212, 209, 136, 12, 135, 194, 225, 226, 163, 233, 53, 159, 72, 230 };
            byte[] SHV13 = { 80, 119, 218, 79, 40, 83, 174, 187, 62, 36, 41, 153, 41, 23, 204, 50, 125, 77, 243, 250, 140, 103, 193, 6, 32, 6, 129, 211, 179, 143, 52, 223 };
            byte[] SHV14 = { 145, 21, 127, 52, 96, 89, 105, 166, 34, 9, 85, 222, 62, 28, 69, 34, 251, 236, 98, 123, 161, 128, 74, 105, 11, 62, 106, 208, 249, 253, 45, 129 };
            byte[] SHV15 = { 48, 102, 225, 146, 16, 100, 182, 160, 84, 119, 45, 132, 158, 255, 70, 190, 250, 155, 136, 5, 255, 155, 16, 232, 176, 86, 63, 160, 195, 11, 30, 232 };
            byte[] SHV16 = { 70, 13, 5, 151, 66, 179, 15, 190, 201, 180, 38, 253, 201, 166, 173, 146, 199, 49, 160, 32, 80, 162, 215, 120, 81, 20, 169, 19, 89, 85, 91, 207 };
            byte[] SHV17 = { 69, 231, 11, 17, 252, 226, 115, 221, 128, 180, 12, 32, 31, 48, 56, 178, 72, 177, 110, 120, 16, 105, 144, 30, 28, 217, 136, 172, 38, 128, 49, 25 };
            byte[] SHV18 = { 58, 102, 170, 208, 66, 84, 245, 75, 251, 153, 128, 203, 214, 239, 20, 100, 89, 149, 84, 226, 16, 200, 68, 116, 153, 113, 34, 76, 152, 191, 69, 237 };

            // array for each line of code that will compare each line of code to propor hash value...
            byte[] compareHashValue0;
            byte[] compareHashValue1;
            byte[] compareHashValue2;
            byte[] compareHashValue3;
            byte[] compareHashValue4;
            byte[] compareHashValue5;
            byte[] compareHashValue6;
            byte[] compareHashValue7;
            byte[] compareHashValue8;
            byte[] compareHashValue9;
            byte[] compareHashValue10;
            byte[] compareHashValue11;
            byte[] compareHashValue12;
            byte[] compareHashValue13;
            byte[] compareHashValue14;
            byte[] compareHashValue15;
            byte[] compareHashValue16;
            byte[] compareHashValue17;
            byte[] compareHashValue18;

            //to convert string to an array of "Unicode bytes"
            UnicodeEncoding ue = new UnicodeEncoding();

            //converting each line into an array of bytes
            byte[] messageBytes0 = ue.GetBytes(story[0]);
            byte[] messageBytes1 = ue.GetBytes(story[1]);
            byte[] messageBytes2 = ue.GetBytes(story[2]);
            byte[] messageBytes3 = ue.GetBytes(story[3]);
            byte[] messageBytes4 = ue.GetBytes(story[4]);
            byte[] messageBytes5 = ue.GetBytes(story[5]);
            byte[] messageBytes6 = ue.GetBytes(story[6]);
            byte[] messageBytes7 = ue.GetBytes(story[7]);
            byte[] messageBytes8 = ue.GetBytes(story[8]);
            byte[] messageBytes9 = ue.GetBytes(story[9]);
            byte[] messageBytes10 = ue.GetBytes(story[10]);
            byte[] messageBytes11 = ue.GetBytes(story[11]);
            byte[] messageBytes12 = ue.GetBytes(story[12]);
            byte[] messageBytes13 = ue.GetBytes(story[13]);
            byte[] messageBytes14 = ue.GetBytes(story[14]);
            byte[] messageBytes15 = ue.GetBytes(story[15]);
            byte[] messageBytes16 = ue.GetBytes(story[16]);
            byte[] messageBytes17 = ue.GetBytes(story[17]);
            byte[] messageBytes18 = ue.GetBytes(story[18]);

            //this is to create the hash values
            SHA256 shHash = SHA256.Create();

            //creating hash values for each line of the current code that will be compared to correct hash values
            compareHashValue0 = shHash.ComputeHash(messageBytes0);
            compareHashValue1 = shHash.ComputeHash(messageBytes1);
            compareHashValue2 = shHash.ComputeHash(messageBytes2);
            compareHashValue3 = shHash.ComputeHash(messageBytes3);
            compareHashValue4 = shHash.ComputeHash(messageBytes4);
            compareHashValue5 = shHash.ComputeHash(messageBytes5);
            compareHashValue6 = shHash.ComputeHash(messageBytes6);
            compareHashValue7 = shHash.ComputeHash(messageBytes7);
            compareHashValue8 = shHash.ComputeHash(messageBytes8);
            compareHashValue9 = shHash.ComputeHash(messageBytes9);
            compareHashValue10 = shHash.ComputeHash(messageBytes10);
            compareHashValue11 = shHash.ComputeHash(messageBytes11);
            compareHashValue12 = shHash.ComputeHash(messageBytes12);
            compareHashValue13 = shHash.ComputeHash(messageBytes13);
            compareHashValue14 = shHash.ComputeHash(messageBytes14);
            compareHashValue15 = shHash.ComputeHash(messageBytes15);
            compareHashValue16 = shHash.ComputeHash(messageBytes16);
            compareHashValue17 = shHash.ComputeHash(messageBytes17);
            compareHashValue18 = shHash.ComputeHash(messageBytes18);

            //Match is defaulted as true
            bool Match = true;

            //for loop for every line of the story that is comparing both hash values
            //loop for every single line of story
            for (int x = 0; x < SHV0.Length; x++)
            {
                //if they do not match, "match" will turn false, incinuating you that the integrity of story is false.....
                if (SHV0[x] != compareHashValue0[x])
                {
                    Match = false;
                }
            }

            for (int x = 0; x < SHV1.Length; x++)
            {
                if (SHV1[x] != compareHashValue1[x])
                {
                Match = false;
                }
            }

            for (int x = 0; x < SHV2.Length; x++)
            {
                if (SHV2[x] != compareHashValue2[x])
                {
                    Match = false;
                }
            }

            for (int x = 0; x < SHV3.Length; x++)
            {
                if (SHV3[x] != compareHashValue3[x])
                {
                    Match = false;
                }
            }

            for (int x = 0; x < SHV4.Length; x++)
            {
                if (SHV4[x] != compareHashValue4[x])
                {
                    Match = false;
                }
            }

            for (int x = 0; x < SHV5.Length; x++)
            {
                if (SHV5[x] != compareHashValue5[x])
                {
                    Match = false;
                }
            }

            for (int x = 0; x < SHV6.Length; x++)
            {
                if (SHV6[x] != compareHashValue6[x])
                {
                    Match = false;
                }
            }

            for (int x = 0; x < SHV7.Length; x++)
            {
                if (SHV7[x] != compareHashValue7[x])
                {
                    Match = false;
                }
            }

            for (int x = 0; x < SHV8.Length; x++)
            {
                if (SHV8[x] != compareHashValue8[x])
                {
                    Match = false;
                }
            }


            for (int x = 0; x < SHV9.Length; x++)
            {
                if (SHV9[x] != compareHashValue9[x])
                {
                    Match = false;
                }
            }

            for (int x = 0; x < SHV10.Length; x++)
            {
                if (SHV10[x] != compareHashValue10[x])
                {
                    Match = false;
                }
            }

            for (int x = 0; x < SHV11.Length; x++)
            {
                if (SHV11[x] != compareHashValue11[x])
                {
                    Match = false;
                }
            }

            for (int x = 0; x < SHV12.Length; x++)
            {
                if (SHV12[x] != compareHashValue12[x])
                {
                    Match = false;
                }
            }
            for (int x = 0; x < SHV13.Length; x++)
            {
                if (SHV13[x] != compareHashValue13[x])
                {
                    Match = false;
                }
            }

            for (int x = 0; x < SHV14.Length; x++)
            {
                if (SHV14[x] != compareHashValue14[x])
                {
                    Match = false;
                }
            }

            for (int x = 0; x < SHV15.Length; x++)
            {
                if (SHV15[x] != compareHashValue15[x])
                {
                    Match = false;
                }
            }

            for (int x = 0; x < SHV16.Length; x++)
            {
                if (SHV16[x] != compareHashValue16[x])
                {
                    Match = false;
                }
            }

            for (int x = 0; x < SHV17.Length; x++)
            {
                if (SHV17[x] != compareHashValue17[x])
                {
                    Match = false;
                }
            }

            for (int x = 0; x < SHV18.Length; x++)
            {
                if (SHV18[x] != compareHashValue18[x])
                {
                    Match = false;
                }
            }





            //what you will see if the codes match and this will take you to the game
            if (Match)
            {
                Console.WriteLine();
                Console.WriteLine("Integrity check: Successful");
                Console.WriteLine();
                Console.WriteLine("Taking you to game now....");
                MiniGameEngine();
            }

            //what you will see if codes don't match and this will take you back to main menu
            else
            {
                Console.WriteLine();
                Console.WriteLine("Integrity check: Failed.");
                Console.WriteLine();
                Console.WriteLine("ERROR:");
                Console.WriteLine("Cannot play game because story data is not correct, make sure story data is correct...");
                Console.WriteLine();
                Console.WriteLine("Taking you back to main menu........");
                Main();

            }
            

            
        }
    }
}
