namespace MauiApp2;

public partial class DynamicControlsPage : ContentPage
{
    
    List<Monkey> MonkeyList;
    int currIndex = 0;
    public DynamicControlsPage()
        {
            InitializeComponent();
            MonkeyList = Monkey.GetMonkeys();
            //הוספת הפקדים בצורה דינאמית
            InitializeControlls();
        }

        private void InitializeControlls()
        {
            //Add your Code Here

            AddLayout();  //הוסף פריסה

            AddImage();//הוסף את תווית

            AddButtons(); //הוסף כפתורים

        }

        private void AddLayout()
        {
            //יצירת פריסה חדשה
            StackLayout stackLayout = new StackLayout();
            //לאורך או לרוחב
            stackLayout.Orientation = StackOrientation.Vertical;
            //רווח
            stackLayout.Padding = new Thickness(30, 0);
            //המרחק בין הפקדים בתוך הפריסה
            stackLayout.Spacing = 25;
            stackLayout.BackgroundColor = Colors.Brown;

            //מיקום ביחס למסך
            stackLayout.VerticalOptions = LayoutOptions.Center;
            //הצבת הפקד בתוך המסך
            this.Content = stackLayout;

        }
        private void AddImage()
        {
            //יצירת הפקד
            Image img = new Image()
            {
                Source = MonkeyList[currIndex].Image,
                HeightRequest = 350
            };
            StackLayout stk = (StackLayout)this.Content;
            stk.Children.Add(img);
        }

        //כפתורים
        private void AddButtons()
        {
            //נאתר את הפריסה
            StackLayout stk = (StackLayout)this.Content;
            //ניצור כפתור 1==="\uef7d"
            Button upBtn = new Button()
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = "לחץ למעלה"

            };
            //הוספת איקון לכפתור
            upBtn.ImageSource = new FontImageSource()
            {
                FontFamily = "MaterialSymbolsSharp",
                Glyph = "\uef7d",
                Color = Color.FromHex("#db1442")
            };
            //הרשמה לאירוע
            upBtn.Clicked += ClickedUpEvent;

            //כפתור 2
            //"\ue941"

            Button downBtn = new Button()
            {
                HorizontalOptions
           = LayoutOptions.Center,
                Text = "לחץ למטה"

            };
            //הוספת איקון לכפתור
            downBtn.ImageSource = new FontImageSource()
            {
                FontFamily = "MaterialSymbolsSharp",
                Glyph = "\uef7d",
                Color = Color.FromHex("#db1442")
            };
        //הרשמה לאירוע
        //הרשמה לאירוע באמצעות anoymous functions =>
        downBtn.Clicked += ClickedDownEvent;

            //חיבור הפקדים לLAYOUT
            stk.Children.Insert(0, upBtn);
            stk.Children.Add(downBtn);
        }

        private void ClickedUpEvent(object sender, EventArgs e)
        {
            
            StackLayout stk = (StackLayout)this.Content;
            Image img = stk.Children.FirstOrDefault(x => x is Image) as Image;
        currIndex++;
        if (currIndex >= MonkeyList.Count) currIndex = 0;
        img.Source = MonkeyList[currIndex].Image; 
        }
    private void ClickedDownEvent(object sender, EventArgs e)
    {

        StackLayout stk = (StackLayout)this.Content;
        Image img = stk.Children.FirstOrDefault(x => x is Image) as Image;
        currIndex--;
        if (currIndex < 0) currIndex = MonkeyList.Count-1;
        img.Source = MonkeyList[currIndex].Image;
    }
}

