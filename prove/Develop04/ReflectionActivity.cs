public class ReflectionActivity : Activiy
{
    private List<Prompts> _promptList = new List<Prompts>();
    private List<ReflectionQuestion> _refQuestions = new List<ReflectionQuestion>();
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
        Console.Clear();
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
                DisplayRandomQuestion();
                decide = "Displayed";
            }
            else if(decide == "Spinning")
            {
                
            }
            
            if (countLeft <= 0)
            {
                timer.Stop();
                decide = "";
            }
		}

        timer.Elapsed += ( sender, e ) => HandleTimer(sender, e);
		timer.Start();

		//Console.ReadLine(); // To make sure the console app keeps running.
        System.Threading.Thread.Sleep((GetDuration() * 1000));

        timer.Dispose();
        Console.WriteLine("_");
    }
}