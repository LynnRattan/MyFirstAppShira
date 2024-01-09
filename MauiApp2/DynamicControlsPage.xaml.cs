namespace MauiApp2;

public partial class DynamicControlsPage : ContentPage
{
    
    List<Monkey> MonkeyList;
    int currIndex = 0;
    public DynamicControlsPage()
        {
            InitializeComponent();
            MonkeyList = Monkey.GetMonkeys();
            //����� ������ ����� �������
            InitializeControlls();
        }

        private void InitializeControlls()
        {
            //Add your Code Here

            AddLayout();  //���� �����

            AddImage();//���� �� �����

            AddButtons(); //���� �������

        }

        private void AddLayout()
        {
            //����� ����� ����
            StackLayout stackLayout = new StackLayout();
            //����� �� �����
            stackLayout.Orientation = StackOrientation.Vertical;
            //����
            stackLayout.Padding = new Thickness(30, 0);
            //����� ��� ������ ���� ������
            stackLayout.Spacing = 25;
            stackLayout.BackgroundColor = Colors.Brown;

            //����� ���� ����
            stackLayout.VerticalOptions = LayoutOptions.Center;
            //���� ���� ���� ����
            this.Content = stackLayout;

        }
        private void AddImage()
        {
            //����� ����
            Image img = new Image()
            {
                Source = MonkeyList[currIndex].Image,
                HeightRequest = 350
            };
            StackLayout stk = (StackLayout)this.Content;
            stk.Children.Add(img);
        }

        //�������
        private void AddButtons()
        {
            //���� �� ������
            StackLayout stk = (StackLayout)this.Content;
            //����� ����� 1==="\uef7d"
            Button upBtn = new Button()
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = "��� �����"

            };
            //����� ����� ������
            upBtn.ImageSource = new FontImageSource()
            {
                FontFamily = "MaterialSymbolsSharp",
                Glyph = "\uef7d",
                Color = Color.FromHex("#db1442")
            };
            //����� ������
            upBtn.Clicked += ClickedUpEvent;

            //����� 2
            //"\ue941"

            Button downBtn = new Button()
            {
                HorizontalOptions
           = LayoutOptions.Center,
                Text = "��� ����"

            };
            //����� ����� ������
            downBtn.ImageSource = new FontImageSource()
            {
                FontFamily = "MaterialSymbolsSharp",
                Glyph = "\uef7d",
                Color = Color.FromHex("#db1442")
            };
        //����� ������
        //����� ������ ������� anoymous functions =>
        downBtn.Clicked += ClickedDownEvent;

            //����� ������ �LAYOUT
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

