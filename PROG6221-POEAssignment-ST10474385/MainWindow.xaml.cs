using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace PROG6221_POEAssignment_ST10474385
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string sName = "";

        Random random = new Random();

        // Keeps track of the current topic
        string currentTopic = "";

        // Memory variables
        string favouriteTopic = "";

        // Task / Reminder memory
        List<string> userTasks = new List<string>();

        // Password responses
        List<string> passwordResponses = new List<string>()
        {
            "Use strong passwords with uppercase, lowercase, numbers, and symbols.",
            "Avoid using personal information like birthdays in your passwords.",
            "Use a different password for every account you create.",
            "Consider using a password manager to store passwords safely."
        };

        // Scam responses
        List<string> scamResponses = new List<string>()
        {
            "Be cautious of messages asking for urgent payments or personal details.",
            "Scammers often pretend to be trusted companies or banks.",
            "Never click suspicious links from unknown senders.",
            "If something sounds too good to be true, it probably is."
        };

                // Privacy responses
        List<string> privacyResponses = new List<string>()
        {
            "Limit the personal information you share online.",
            "Check privacy settings on social media regularly.",
            "Avoid sharing your location publicly on apps.",
            "Use two-factor authentication to improve account privacy."
        };

        // Phishing responses
        List<string> phishingResponses = new List<string>()
        {
            "Always verify email addresses before clicking links.",
            "Phishing emails often create a false sense of urgency.",
            "Do not download attachments from unknown senders.",
            "Look for spelling mistakes and suspicious URLs in emails."
        };

        // Safe Browsing responses
        List<string> browsingResponses = new List<string>()
        {
            "Only visit websites that use HTTPS.",
            "Avoid downloading files from untrusted websites.",
            "Keep your browser and antivirus software updated.",
            "Do not enter personal information on suspicious websites."
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        // Submit Name
        private void SubmitName_Click(object sender, RoutedEventArgs e)
        {
            sName = txtName.Text;

            if (string.IsNullOrWhiteSpace(sName))
            {
                txtOutput.Text = "Please enter your name.";
            }
            else
            {
                txtOutput.Text = $"Wow, {sName} sounds like a great name!";
            }
        }

        // How do you feel?
        private void Feel_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Text =
                $"I feel great. Thank you so much for asking me {sName}. " +
                $"I hope that as your AI assistant I can be helpful to you.";
        }

        // Purpose
        private void Purpose_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Text =
                $"My purpose as an AI Assistant is to help you be more aware " +
                $"of the dangers of the internet in terms of Cybersecurity, {sName}.";
        }

        // Show Cybersecurity Panel
        private void Cyber_Click(object sender, RoutedEventArgs e)
        {
            CyberPanel.Visibility = Visibility.Visible;

            txtOutput.Text =
                $"Okay then {sName}, choose a cybersecurity topic to learn about.";
        }

        // Password Safety
        private void Password_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Text =
                "Password safety refers to the collection of practices and " +
                "technologies used to protect your accounts from unauthorized access. " +
                "It serves as your primary line of defense against hackers.";
        }

        // Phishing
        private void Phishing_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Text =
                "Phishing is a cyberattack where scammers impersonate trusted " +
                "entities via email, text, or phone to steal sensitive information.";
        }

        // Safe Browsing
        private void Browsing_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Text =
                "Safe Browsing helps protect users from phishing attacks, malware, " +
                "and other dangerous websites across desktop and mobile platforms.";
        }

        // Keyword Recognition + Random Responses + Conversation Flow + Sentiment Detection
        private void AskAI_Click(object sender, RoutedEventArgs e)
        {
            string question = txtQuestion.Text.ToLower();

            string sentimentResponse = "";


            // SENTIMENT DETECTION
            if (question.Contains("worried") ||
                question.Contains("scared") ||
                question.Contains("afraid") ||
                question.Contains("nervous"))
            {
                sentimentResponse =
                "It's understandable to feel that way. Cyber threats can be convincing, " +
                "but learning about cybersecurity keeps you safer.\n\n";
            }


            else if (question.Contains("confused") ||
                     question.Contains("frustrated"))
            {
                sentimentResponse =
                "Cybersecurity can feel complicated, but I will explain it step by step.\n\n";
            }



            // ============================
            // TASK / REMINDER NLP
            // ============================

            if (question.Contains("task") ||
               question.Contains("remind") ||
               question.Contains("reminder"))
            {

                string task = ExtractTask(question);


                if (!string.IsNullOrWhiteSpace(task))
                {

                    userTasks.Add(task);


                    txtOutput.Text =
                    $"Task added: '{task}'. " +
                    "Would you like to set a reminder for this task?";

                }

                else
                {

                    txtOutput.Text =
                    "I detected a task request, but I could not understand the task.";

                }


                return;
            }



            // SHOW TASK HISTORY

            if (question.Contains("what have you done") ||
               question.Contains("show tasks") ||
               question.Contains("my tasks") ||
               question.Contains("summary"))
            {


                if (userTasks.Count == 0)
                {

                    txtOutput.Text =
                    "I have not added any tasks yet.";

                }

                else
                {

                    StringBuilder summary = new StringBuilder();

                    summary.AppendLine("Here is a summary of recent actions:");

                    for (int i = 0; i < userTasks.Count; i++)
                    {

                        summary.AppendLine(
                        $"{i + 1}. Task added: '{userTasks[i]}'");

                    }


                    txtOutput.Text = summary.ToString();

                }


                return;

            }




            // PASSWORD
            if (question.Contains("password"))
            {

                currentTopic = "password";

                favouriteTopic = "password safety";


                txtOutput.Text =
                sentimentResponse +
                passwordResponses[random.Next(passwordResponses.Count)];

            }



            // PHISHING
            else if (question.Contains("phishing"))
            {

                currentTopic = "phishing";

                favouriteTopic = "phishing awareness";


                txtOutput.Text =
                sentimentResponse +
                phishingResponses[random.Next(phishingResponses.Count)];

            }



            // PRIVACY

            else if (question.Contains("privacy"))
            {

                currentTopic = "privacy";

                favouriteTopic = "privacy";


                txtOutput.Text =
                sentimentResponse +
                privacyResponses[random.Next(privacyResponses.Count)];

            }




            // SCAM

            else if (question.Contains("scam"))
            {

                currentTopic = "scam";

                favouriteTopic = "scam protection";


                txtOutput.Text =
                sentimentResponse +
                scamResponses[random.Next(scamResponses.Count)];

            }




            // BROWSING

            else if (question.Contains("browser") ||
                    question.Contains("browsing"))
            {

                currentTopic = "browsing";

                favouriteTopic = "safe browsing";


                txtOutput.Text =
                sentimentResponse +
                browsingResponses[random.Next(browsingResponses.Count)];

            }



            else
            {

                txtOutput.Text =
                sentimentResponse +
                "I did not understand. Try asking about passwords, phishing, privacy, or tasks.";

            }

        }

        private string ExtractTask(string input)
        {

            string task = input;


            // Remove common command words

            task = task.Replace("remind me to", "");
            task = task.Replace("remind me", "");
            task = task.Replace("add a task to", "");
            task = task.Replace("add task", "");
            task = task.Replace("create a task", "");
            task = task.Replace("set a reminder for", "");
            task = task.Replace("task", "");



            // Remove time words

            task = task.Replace("tomorrow", "");
            task = task.Replace("today", "");
            task = task.Replace("later", "");



            task = task.Trim();



            // Capitalise first letter

            if (task.Length > 0)
            {

                task =
                char.ToUpper(task[0]) +
                task.Substring(1);

            }


            return task;

        }

        // QUIZ VARIABLES

        int quizIndex = 0;

        int score = 0;


        class QuizQuestion
        {
            public string Question;
            public string[] Answers;
            public int CorrectAnswer;


            public QuizQuestion(string q, string[] a, int c)
            {
                Question = q;
                Answers = a;
                CorrectAnswer = c;
            }
        }



        List<QuizQuestion> quizQuestions = new List<QuizQuestion>()
        {

        new QuizQuestion(
        "What should you do if you receive a suspicious email asking for your password?",
        new string[]
        {
            "Reply with password",
            "Delete immediately",
            "Report it as phishing",
            "Ignore it"
        },2),


        new QuizQuestion(
        "True or False: Using the same password everywhere is safe.",
        new string[]
        {
            "True",
            "False"
        },1),


        new QuizQuestion(
        "Which makes a password stronger?",
        new string[]
        {
            "Your birthday",
            "Short words",
            "Numbers and symbols",
            "Your name"
        },2),


        new QuizQuestion(
        "What does phishing attempt to steal?",
        new string[]
        {
            "Sensitive information",
            "Computer speed",
            "Internet data",
            "Battery power"
        },0),


        new QuizQuestion(
        "True or False: HTTPS websites are usually safer.",
        new string[]
        {
            "True",
            "False"
        },0),


        new QuizQuestion(
        "Which should you avoid clicking?",
        new string[]
        {
            "Trusted links",
            "Unknown links",
            "Your bookmarks",
            "School websites"
        },1),


        new QuizQuestion(
        "What helps protect online accounts?",
        new string[]
        {
            "Two-factor authentication",
            "Sharing passwords",
            "Using simple passwords",
            "Disabling security"
        },0),


        new QuizQuestion(
        "Malware is:",
        new string[]
        {
            "A type of food",
            "A harmful program",
            "A password",
            "A browser"
        },1),


        new QuizQuestion(
        "True or False: You should install updates regularly.",
        new string[]
        {
            "True",
            "False"
        },0),


        new QuizQuestion(
        "Safe browsing means:",
        new string[]
        {
            "Visiting random websites",
            "Protecting yourself online",
            "Downloading everything",
            "Sharing private details"
        },1)

        };

        private void Quiz_Click(object sender, RoutedEventArgs e)
        {

            QuizPanel.Visibility = Visibility.Visible;

            CyberPanel.Visibility = Visibility.Collapsed;


            quizIndex = 0;
            score = 0;


            txtScore.Text = "Score: 0";


            LoadQuestion();

        }

        private void LoadQuestion()
        {

            AnswerPanel.Children.Clear();


            if (quizIndex >= quizQuestions.Count)
            {

                FinishQuiz();

                return;

            }


            QuizQuestion q = quizQuestions[quizIndex];


            txtQuizQuestion.Text =
                $"Question {quizIndex + 1}/{quizQuestions.Count}\n\n{q.Question}";


            for (int i = 0; i < q.Answers.Length; i++)
            {

                Button answer = new Button();

                answer.Content = q.Answers[i];

                answer.Tag = i;


                answer.Margin = new Thickness(5);

                answer.Height = 35;


                answer.Click += Answer_Click;


                AnswerPanel.Children.Add(answer);

            }


            btnNext.Visibility = Visibility.Collapsed;

        }

        private void Answer_Click(object sender, RoutedEventArgs e)
        {


            Button clicked = sender as Button;


            int selected =
                (int)clicked.Tag;


            QuizQuestion q =
                quizQuestions[quizIndex];


            if (selected == q.CorrectAnswer)
            {

                score++;


                txtOutput.Text =
                "Correct! Great cybersecurity knowledge.";

            }

            else
            {

                txtOutput.Text =
                $"Incorrect. Correct answer: {q.Answers[q.CorrectAnswer]}";

            }



            txtScore.Text =
                $"Score: {score}";


            foreach (Button b in AnswerPanel.Children)
            {
                b.IsEnabled = false;
            }


            btnNext.Visibility =
                Visibility.Visible;


        }

        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {

            quizIndex++;

            LoadQuestion();

        }

        private void FinishQuiz()
        {

            QuizPanel.Visibility =
                Visibility.Visible;


            AnswerPanel.Children.Clear();


            txtQuizQuestion.Text =
                $"Quiz Complete!\n\nFinal Score: {score}/{quizQuestions.Count}";


            btnNext.Visibility =
                Visibility.Collapsed;



            if (score >= 8)
            {

                txtOutput.Text =
                "Excellent work! You're a cybersecurity pro!";

            }

            else if (score >= 5)
            {

                txtOutput.Text =
                "Good job! Keep learning to stay safe online.";

            }

            else
            {

                txtOutput.Text =
                "Keep practicing cybersecurity skills to improve.";

            }

        }
    }
}