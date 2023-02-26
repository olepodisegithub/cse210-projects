public class ReflectionActivity : Activiy
{
    private List<Prompts> _promptList = new List<Prompts>();
    private List<ReflectionQuestion> _refQuestions = new List<ReflectionQuestion>();
    System.Timers.Timer _reflectTimer = new (interval: 125 );
    public ReflectionActivity(string activityname,
                            string description,
                            string preparingmessage,
                            int pasueduration) : 
                            
                            base( activityname, 
                            description, 
                            preparingmessage, 
                            pasueduration)
    {
        CreatePromptList();
        CreateQuestionList();
    }
    public void CreatePromptList()
    {
        string[] entrylines = System.IO.File.ReadAllLines("PromptList.txt");
        foreach(string item in entrylines)
        {
            Prompts pro = new Prompts(item);
            _promptList.Add(pro);
        }
    }
    public void CreateQuestionList()
    {
        string[] entrylines = System.IO.File.ReadAllLines("Questions.txt");
        foreach(string item in entrylines)
        {
            ReflectionQuestion ques = new ReflectionQuestion(item);
            _refQuestions.Add(ques);
        }
    }
    public void Reflect()
    {
        DisplayStartingMessage();
        DisplayDescription();
        SetDurationFromInput("How long in seconds would you like for your session ?");

        DisplayPreparingMessage();
        DisplaySpinner(3);

        Console.Clear();
        Console.Clear();
        Console.WriteLine("Consider the following prompt!");
        Console.WriteLine("");
        DisplayRandomPrompt();

        Console.WriteLine("");
        Console.WriteLine("Press enter to continue!");
        Console.ReadLine();

        Console.WriteLine("Please reflect on questions related to this experience as follows!");
        DisplaySpinner(3);

        Console.Clear();
        ReflectionCountDown();

        DisplayEndingMessage();
        DisplaySpinner(3);
    }

    public void DisplayRandomPrompt()
    {
        var rnd = new Random();
        rnd = new Random();
        int index = rnd.Next(_promptList.Count);
        _promptList[index].DisplayPrompt();
    }

    public void DisplayRandomQuestion()
    {
        var rnd = new Random();
        rnd = new Random();
        int index = rnd.Next(_refQuestions.Count);
        _refQuestions[index].DisplayQuestion();
    }

    public void ReflectionCountDown()
    {
        string decide = "Display Question";

        System.Timers.Timer timer = new (interval: 1000 );
        
        int countLeft = ((GetDuration() * 1000));

        void HandleTimer(object sender, EventArgs e)
		{
            countLeft = countLeft - 1000;

            if(decide == "Display Question")
            {
                Console.Clear();
                DisplayRandomPrompt();
                DisplayRandomQuestion();
                decide = "Displayed";
            }
            else if(decide == "Displayed")
            {
                decide = "Spinning";
                decide = DisplayReflectionSpinner(10);
            }
            else if(decide == "Spinned")
            {
                Console.Clear();
                DisplayRandomPrompt();
                DisplayRandomQuestion();
                decide = "Displayed";
            }
            else if(decide == "Spinning")
            {
                
            }
            else
            {
                
            }
            
            if (countLeft <= 0)
            {
                timer.Stop();
                decide = "";
                _reflectTimer.Stop();
            }
		}

        timer.Elapsed += ( sender, e ) => HandleTimer(sender, e);
		timer.Start();

		//Console.ReadLine(); // To make sure the console app keeps running.
        System.Threading.Thread.Sleep((GetDuration() * 1000));

        timer.Dispose();
        _reflectTimer.Dispose();
        Console.WriteLine("_");
    }

    public string DisplayReflectionSpinner(int duration)
    {
        try
        {
            int spinnumber = 1;
        
            Console.WriteLine("x");

            _reflectTimer = new (interval: 125 );

            int countLeft = (duration * 1000);
            void HandleTimer(object sender, EventArgs e)
            {
                countLeft = countLeft - 125;
                
                ClearLine();

                if(spinnumber == 1)
                {
                    SpinnerOne();
                }
                else if(spinnumber == 2)
                {
                    SpinnerTwo();
                }
            

                if(spinnumber == 2)
                {
                    spinnumber = 1;
                }
                else
                {
                    spinnumber = spinnumber + 1;
                }         

                if (countLeft <= 0)
                {
                    _reflectTimer.Stop();
                }

            }

            _reflectTimer.Elapsed += ( sender, e ) => HandleTimer(sender, e);
            _reflectTimer.Start();

            //Console.ReadLine(); // To make sure the console app keeps running.
            System.Threading.Thread.Sleep(duration * 1000);
        
            _reflectTimer.Dispose();       
            Console.WriteLine("_");
           
        }
        catch (IOException e)
        {
            Console.WriteLine("IOException source: ", e.Source);
        }
         return "Spinned";
    }
}