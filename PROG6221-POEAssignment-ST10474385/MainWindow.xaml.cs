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

            // SENTIMENT DETECTION
            string sentimentResponse = "";

            if (question.Contains("worried") ||
                question.Contains("scared") ||
                question.Contains("afraid") ||
                question.Contains("nervous"))
            {
                sentimentResponse =
                    "It's completely understandable to feel that way. " +
                    "Cyber threats can be very convincing, but staying informed helps you stay safe.\n\n";
            }

            else if (question.Contains("frustrated") ||
                     question.Contains("confused") ||
                     question.Contains("overwhelmed"))
            {
                sentimentResponse =
                    "I understand that cybersecurity can feel overwhelming at times. " +
                    "Don't worry — I'll keep things simple and help you step by step.\n\n";
            }

            else if (question.Contains("curious") ||
                     question.Contains("interested"))
            {
                sentimentResponse =
                    "I’m glad you’re curious about cybersecurity! " +
                    "Learning about online safety is a great way to protect yourself.\n\n";
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

            // SCAM
            else if (question.Contains("scam"))
            {
                currentTopic = "scam";
                favouriteTopic = "scam protection";

                txtOutput.Text =
                    sentimentResponse +
                    scamResponses[random.Next(scamResponses.Count)];
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

            // PHISHING
            else if (question.Contains("phishing"))
            {
                currentTopic = "phishing";
                favouriteTopic = "phishing awareness";

                txtOutput.Text =
                    sentimentResponse +
                    phishingResponses[random.Next(phishingResponses.Count)];
            }

            // SAFE BROWSING
            else if (question.Contains("browsing") || question.Contains("safe browsing"))
            {
                currentTopic = "browsing";
                favouriteTopic = "safe browsing";

                txtOutput.Text =
                    sentimentResponse +
                    browsingResponses[random.Next(browsingResponses.Count)];
            }

            // FOLLOW-UP QUESTIONS
            else if (question.Contains("more") ||
                     question.Contains("another") ||
                     question.Contains("explain"))
            {
                HandleFollowUp();
            }

            // MEMORY RECALL
            else if (question.Contains("remember") ||
                     question.Contains("my favourite topic") ||
                     question.Contains("what do i like"))
            {
                if (!string.IsNullOrEmpty(favouriteTopic))
                {
                    txtOutput.Text =
                        $"{sName}, I remember that you're interested in {favouriteTopic}. " +
                        $"It's an important part of staying safe online!";
                }
                else
                {
                    txtOutput.Text =
                        "I don't know your favourite cybersecurity topic yet. " +
                        "Ask me about one first!";
                }
            }

            // UNKNOWN QUESTION
            else
            {
                txtOutput.Text =
                    sentimentResponse +
                    "Sorry, I could not understand that topic. " +
                    "Try asking about passwords, scams, privacy, phishing, or safe browsing.";
            }
        }

        // Handles follow-up questions
        private void HandleFollowUp()
        {
            switch (currentTopic)
            {
                case "password":
                    txtOutput.Text =
                    $"{sName}, since you're interested in passwords: " +
                    passwordResponses[random.Next(passwordResponses.Count)];
                    break;

                case "scam":
                    txtOutput.Text =
                    $"{sName}, since you're interested in scams: " +
                    scamResponses[random.Next(scamResponses.Count)];
                    break;

                case "privacy":
                    txtOutput.Text =
                    $"{sName}, since you're interested in privacy: " +
                    privacyResponses[random.Next(privacyResponses.Count)];
                    break;

                case "phishing":
                    txtOutput.Text =
                    $"{sName}, since you're interested in phishing: " +
                    phishingResponses[random.Next(phishingResponses.Count)];
                    break;

                case "browsing":
                    txtOutput.Text =
                    $"{sName}, since you're interested in browsing: " +
                    browsingResponses[random.Next(browsingResponses.Count)];
                    break;

                default:
                    txtOutput.Text =
                        "Please ask about a cybersecurity topic first.";
                    break;
            }
        }
    }
}