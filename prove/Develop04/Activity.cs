using System.Timers;
public class Activiy
{
    private string _activityName = "";
    private string _description = "";
    private int _duration = 0;
    private string _preparingMessage = "";
    private int _pauseDuration = 0;

     public Activiy(string activityname,string description,
                    string preparingmessage,
                    int pasueduration)
    {
        _activityName = activityname;
        _description = description;
        _preparingMessage = preparingmessage;
        _pauseDuration = pasueduration;
    }

    public void DisplayDescription()
    {
        Console.WriteLine("");
        Console.WriteLine($"{_description}");
    }
    public void SetDurationFromInput(string displaytext)
    {
        Boolean _responseEntered = false;
        int _response = 0;

        while (_responseEntered == false)
        {
            Console.WriteLine("");
            Console.Write($"{displaytext}");
            _response = int.Parse(Console.ReadLine());
            if (_response == 0)
            {
                _responseEntered = false;
            }
            else
            {
                _responseEntered = true;
            }   
        }
        _duration = _response;
    }
    public int GetDuration()
    {
        return _duration;
    }

    public string GetPreparingMessage()
    {
        return _preparingMessage;
    }
    public void DisplayStartingMessage()
    {
        Console.WriteLine("");
        Console.WriteLine($"Welcome to the {_activityName}.");
    }
    public void DisplayPreparingMessage()
    {
        Console.WriteLine("");
        Console.WriteLine($"{_preparingMessage}");
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("");
        Console.WriteLine($"Well done!");
        Console.WriteLine($"You have completed another {_duration} seconds of {_activityName}");
    }
    public void DisplayCountDown(string displaytext,int duration)
    {
        System.Timers.Timer timer = new (interval: 1000 );
        
        int countLeft = (duration * 1000);
        void HandleTimer(object sender, EventArgs e)
		{
            countLeft = countLeft - 1000;
            ClearLine();
			Console.WriteLine($"{displaytext}{(countLeft/1000)-1}");
            if (countLeft <= 0)
            {
                timer.Stop();
            }
		}

        timer.Elapsed += ( sender, e ) => HandleTimer(sender, e);
		timer.Start();

		//Console.ReadLine(); // To make sure the console app keeps running.
        System.Threading.Thread.Sleep(duration * 1000);

        timer.Dispose();
        Console.WriteLine("_");
    }
    public void DisplaySpinner(int duration)
    {
        int spinnumber = 1;

        System.Timers.Timer timer = new (interval: 125 );
        
        Console.WriteLine("x");

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
                timer.Stop();
            }

		}

        timer.Elapsed += ( sender, e ) => HandleTimer(sender, e);
		timer.Start();

        //Console.ReadLine(); // To make sure the console app keeps running.
        System.Threading.Thread.Sleep(duration * 1000);
       
        timer.Dispose();       
        Console.WriteLine("_");
    }
    public void SpinnerOne()
    {
        Console.WriteLine("+");
    }
    public void SpinnerTwo()
    {
        Console.WriteLine("x");
    }

    public static void ClearLine()
    {
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth)); 
        Console.SetCursorPosition(0, Console.CursorTop - 1);
    }
}