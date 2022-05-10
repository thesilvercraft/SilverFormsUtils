namespace SilverFormsUtils
{
    public partial class ExampleForm : Form
    {
        public ExampleForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.UseDarkModeBar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.UseDarkModeBar(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.UseDarkModeForThingsInsideOfForm();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.UseDarkModeForThingsInsideOfForm(false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            progressBar1.SetState(ProgressBarExtensions.ProgressBarState.Red);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            progressBar1.SetState(ProgressBarExtensions.ProgressBarState.Yellow);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            progressBar1.SetState(ProgressBarExtensions.ProgressBarState.Green);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.SetRoundPreference(RoundTheWindow.RoundPreference.Round);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.SetRoundPreference(RoundTheWindow.RoundPreference.DoNotRound);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.SetRoundPreference(RoundTheWindow.RoundPreference.RoundSmall);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.UseDarkModeForThingsInsideOfForm(true, true);
        }


        private void ExampleForm_Load(object sender, EventArgs e)
        {

        }
    }
}