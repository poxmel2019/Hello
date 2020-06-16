using System;
using System.Collections.Generic;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is \"Hello\" game");
            string[] questions = {
                "What is your name",
                "How old are you",
                "Are you a boy",
                "Are you a girl",
                "Name your favourite character",
                "And what is character",
                "Name your unloved character",
                "And what is character"

            };
            List<string> userAnswers = new List<string>();
            for (int i = 0; i < questions.Length; i++)
            {
                bool condition = true;
                while (condition)
                {
                    Console.WriteLine(questions[i]);
                    string userAnswer = Console.ReadLine();
                    if (userAnswer == "q") { return; } 
                    switch(i)
                    {
                        case 0:
                            condition = NameAnswer(userAnswer, condition, userAnswers);
                            break;
                        case 1:
                            condition = AgeAnswer(userAnswer, condition, userAnswers);
                            break;
                        case 2:
                        case 3:
                            condition = GenderAnswer(userAnswer,condition, ref i, userAnswers);
                            break;
                        case 4:
                        case 6:
                            condition = HeroAnswer(userAnswer, condition, userAnswers,i);
                            break;
                        case 5:
                        case 7:
                            condition = HeroQualityAnswer(userAnswer, condition, userAnswers, i);
                            break;
                    }
                    
                }
                
            }
            string story = $"Once upon a time {userAnswers[3]} and Red Hat walked in the forest. " +
                    $"But suddenly they saw a {userAnswers[5]}." +
                    $"It was very angry and {userAnswers[6]}. " +
                    $"However, {userAnswers[3]} was very {userAnswers[4]}. " +
                    $"He and Red Hat started to loudly scream at {userAnswers[6]}. " +
                    $"And it dissapeared. " +
                    $"Red hat and {userAnswers[3]} become very happy and continued their walking." +
                    $"The end." +
                    $"\nHello!";
            Console.WriteLine($"Ok {userAnswers[2]} {userAnswers[0]}. Listen to my story");
            Console.WriteLine(story);
            Console.ReadLine();
            
        }
        

        static bool NameAnswer(string userAnswer, bool condition, List<string> userAnswers)
        {
           
            try
            {
                int num = Convert.ToInt32(userAnswer);
                Console.WriteLine("Name can't be numeric");
               
            }
            catch (FormatException)
            {
                if (string.IsNullOrEmpty(userAnswer))
                {
                    Console.WriteLine("Enter name please");
                    condition = true;
                }
                else { userAnswers.Add(userAnswer); condition = false; }
                
            }
            return condition;
        }
        static bool AgeAnswer(string userAnswer, bool condition, List<string> userAnswers)
        {
           
            try
            {
                int num = Convert.ToInt32(userAnswer);
                userAnswers.Add(userAnswer);
                condition = false;
            }
            catch (FormatException)
            {
                if (string.IsNullOrEmpty(userAnswer))
                {
                    Console.WriteLine("Enter age please");
                    
                }
                else
                {
                    Console.WriteLine("Age must me numeric");
                }
                condition = true;

            }
            return condition;
        }
        static bool GenderAnswer(string userAnswer, bool condition, ref int i, List<string> userAnswers)
        {
            
            if (string.IsNullOrEmpty(userAnswer))
            {
                Console.WriteLine("Answer, please");
                condition = true;

            }   
            if (userAnswer == "y")
            {
                if (i == 2)
                {
                    Console.WriteLine($"Ok, boy {userAnswers[0]}");
                    userAnswers.Add("boy");
                    i += 1;
                    
                }
                else 
                {
                    Console.WriteLine($"Ok, girl {userAnswers[0]}");
                    userAnswers.Add("girl");
                }
                condition = false;

            }
            else if (userAnswer == "n")
            {
                
                if (i == 3)
                {
                    Console.WriteLine($"Ok, it {userAnswers[0]}");
                    userAnswers.Add("it");
                }

                condition = false;
            }
            else
            {
                Console.WriteLine("Answer should be \"yes\" or \"no\"");
            }
            
            return condition;
        }
        static bool HeroAnswer(string userAnswer, bool condition, List<string> userAnswers, int i)
        {
            string hero = "loved";
            if (i == 6) { hero = "unloved"; }
            
            try
            {
                int num = Convert.ToInt32(userAnswer);
                Console.WriteLine($"{hero} hero name can't be numeric");
                
            }
            catch (FormatException)
            {
                if (string.IsNullOrEmpty(userAnswer))
                {
                    Console.WriteLine($"Enter your {hero} hero, please");
                }
                else { userAnswers.Add(userAnswer.ToUpper()); condition = false; }

            }
            return condition;
        }
        static bool HeroQualityAnswer(string userAnswer, bool condition, List<string> userAnswers, int i)
        {
            string hero = "hero";
            if (i == 7) { hero = "villain"; }
            try
            {
                int num = Convert.ToInt32(userAnswer.ToUpper());
                Console.WriteLine($"{hero} quality can't be numeric");

            }
            catch (FormatException)
            {
                if (string.IsNullOrEmpty(userAnswer))
                {
                    Console.WriteLine($"Enter your {hero} quality, please");
                }
                else { userAnswers.Add(userAnswer.ToUpper()); condition = false; }

            }
            return condition;
        }
        static void VillainAnswer(string userAnswer)
        {
            Console.WriteLine(userAnswer);
        }
        static void VillainQualityAnswer(string userAnswer)
        {
            Console.WriteLine(userAnswer);
        }

    }
}
