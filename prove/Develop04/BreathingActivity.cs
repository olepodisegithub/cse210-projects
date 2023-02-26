public class BreathingActivity : Activiy
{
    private String _alternatingMessage = "in";
    private int _inhailingDuration = 0;
    private int _exhailingDuration = 0;

     public BreathingActivity(string alternatingmessage,
                            int inhailduration,
                            int exhailduration,

                            string activityname,
                            string description,
                            string preparingmessage,
                            int pasueduration) : 
                            
                            base( activityname, 
                            description, 
                            preparingmessage, 
                            pasueduration)
    {
        _alternatingMessage = alternatingmessage;
        _inhailingDuration = inhailduration;
        _exhailingDuration = exhailduration;
    }
    public void Breath()
    {
        DisplayStartingMessage();
        DisplayDescription();
        SetDurationFromInput("How long in seconds would you like for your session ?");
        Console.Clear();
        DisplayPreparingMessage();
        DisplaySpinner(3);
        BreathingDisplayCountDown();
        DisplayEndingMessage();
        DisplaySpinner(4);
    }

    public void BreathingDisplayCountDown()
    {
        System.Timers.Timer timer = new (interval: 1000 );
        
        int countLeft = ((GetDuration() * 1000));
        int countInhale = _inhailingDuration * 1000;
        int countExhale = _exhailingDuration * 1000;
        string displaycount = _inhailingDuration.ToString();

        void HandleTimer(object sender, EventArgs e)
		{
            if (_alternatingMessage == "in")
            {
                countInhale = countInhale - 1000;
                displaycount = (countInhale /1000).ToString();
                ClearLine();
            }
            else if (_alternatingMessage == "out")
            {
                countExhale = countExhale - 1000;
                displaycount = (countExhale /1000).ToString();
                ClearLine();
            }
            
            Console.WriteLine($"Breath {_alternatingMessage}..{displaycount}");
           

            if (countInhale <= 0)
            {
                countInhale = _inhailingDuration * 1000;
                _alternatingMessage = "out";
                displaycount = _exhailingDuration.ToString();
                Console.WriteLine();
            }

            if (countExhale <= 0)
            {
                countExhale = _exhailingDuration * 1000;
                _alternatingMessage = "in";
                displaycount = _inhailingDuration.ToString();
                Console.WriteLine();
                Console.WriteLine();
            }
            
            countLeft = countLeft - 1000;
            
			
            if (countLeft <= 0)
            {
                timer.Stop();
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