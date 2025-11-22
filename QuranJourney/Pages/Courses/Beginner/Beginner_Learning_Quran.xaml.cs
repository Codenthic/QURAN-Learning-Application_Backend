using QuranJourney.Models;

namespace QuranJourney.Pages.Courses.Beginner;

        public partial class Beginner_Learning_Quran : ContentPage
        {
        #region =============================== Fields / Variables =======================================
            private int currentQuestionIndex = 0;
            private string selectedAnswer = string.Empty;
            private bool isAnswerChecked = false;
            private int currentActivityIndex = 0;
            private List<LetterQuizItem> shuffledQuestions;
            private int matchingScore = 0;
            private Button firstSelected = null;
            private Button secondSelected = null;
            private List<Tuple<Button, Button>> matchedPairs = new List<Tuple<Button, Button>>();
            private List<Label> dragSourceLabels = new();
            private List<Button> dropSlotButtons = new();
            private string[] currentCorrectOrder; // expected sequence
            private List<Button> allButtons = new();
            private Dictionary<Button, Color> assignedColors = new();
            private List<Color> pairColors = new()
            {
                Colors.Green,
                Colors.Blue,
                Colors.Orange,
                Colors.Purple,
                Colors.Brown
            };

            private int currentColorIndex = 0;

        #endregion

        #region =============================== Constructor =============================================
        public Beginner_Learning_Quran(int categoryId, string categoryType)
        {
            InitializeComponent();

            // Decide category type
            if (categoryType == "special")
            {
                var category = SpecialLetterRepository.GetCategoryById(1);
                shuffledQuestions = category.QuizItems.OrderBy(x => Guid.NewGuid()).ToList();
            }
            else if (categoryType == "qaida")
            {
                var QaidaCategory = ThaktiRepository.GetQaidaCategoryById(categoryId);
                shuffledQuestions = QaidaCategory.QuizItems.OrderBy(x => Guid.NewGuid()).ToList();
            }
            else
            {
                throw new Exception("Invalid category type");
            }

            // Button events
            CheckButton.Clicked += CheckButton_Clicked;

            // Load first activity
            ShowCurrentActivity();

            allButtons = new List<Button>
            {
                Btn1, Btn2, Btn3, Btn4, Btn5,
                Btn6, Btn7, Btn8, Btn9, Btn10
            };

            foreach (var btn in allButtons)
            {
                btn.Clicked += MatchingPairOption_Clicked;
                btn.BackgroundColor = Colors.White;
            }
            // Progress Bar
            AnimateProgress(0.0);
        }

        #endregion

        private void UpdateCurrentQuestionIndex()
        {
            // Find minimum ActivityCount
            int minCount = shuffledQuestions.Min(x => x.ActivityCount);

            // Find first question with the lowest ActivityCount
            currentQuestionIndex = shuffledQuestions.FindIndex(x => x.ActivityCount == minCount);
        }

        #region =============================== Activity Management ======================================
        //private void ShowCurrentActivity()
        //{
        //        // 1️⃣ Hide all headers & grids
        //        Select_Word_Header.IsVisible = false;
        //        Select_Word_ContentGrid.IsVisible = false;
        //        What_You_Hear_Header.IsVisible = false;
        //        What_You_Hear_ContentGrid.IsVisible = false;
        //        What_Sound_Header.IsVisible = false;
        //        What_Sound_ContentGrid.IsVisible = false;
        //        Correct_Char_Header.IsVisible = false;
        //        Correct_Char_ContentGrid.IsVisible = false;
        //        FillIn_ContentGrid.IsVisible = false;
        //        FillIn_Header.IsVisible = false;

        //    ResetAllOptionButtons();

        //        // 3️⃣ Show current activity
        //        switch (currentActivityIndex)
        //        {
        //            case 0:
        //                Select_Word_Activity(shuffledQuestions[currentQuestionIndex]);
        //                Select_Word_Header.IsVisible = true;
        //                Select_Word_ContentGrid.IsVisible = true;
        //                break;

        //            case 1:
        //                What_You_Hear_Activity(shuffledQuestions[currentQuestionIndex]);
        //                What_You_Hear_Header.IsVisible = true;
        //                What_You_Hear_ContentGrid.IsVisible = true;
        //                break;

        //            case 2:
        //                What_Sound_Hear_LoadQuestion(shuffledQuestions[currentQuestionIndex]);
        //                What_Sound_Header.IsVisible = true;
        //                What_Sound_ContentGrid.IsVisible = true;
        //                break;
        //            case 3:
        //                Correct_Char_Activity(shuffledQuestions[currentQuestionIndex]);
        //                Correct_Char_Header.IsVisible = true;
        //                Correct_Char_ContentGrid.IsVisible = true;
        //                break;
        //            case 4:
        //                FillIn_Activity(shuffledQuestions[currentQuestionIndex]);
        //                FillIn_Header.IsVisible = true;
        //                FillIn_ContentGrid.IsVisible = true;
        //                break;
        //            //case 5:
        //            //    MatchingPair_Activity(shuffledQuestions[currentQuestionIndex]);
        //            //    Matching_pair_Header.IsVisible = true;
        //            //    Matching_pair_ContentGrid.IsVisible = true;
        //            //    break;
        //    }

        //    // Reset selection
        //    selectedAnswer = string.Empty;
        //        CheckButton.BackgroundColor = Color.FromArgb("#E0E0E0");
        //    }
        private void ShowCurrentActivity()
        {
            // FIRST: Pick the correct question dynamically based on ActivityCount
            UpdateCurrentQuestionIndex();

            // Hide all headers & grids
            Select_Word_Header.IsVisible = false;
            Select_Word_ContentGrid.IsVisible = false;
            What_You_Hear_Header.IsVisible = false;
            What_You_Hear_ContentGrid.IsVisible = false;
            What_Sound_Header.IsVisible = false;
            What_Sound_ContentGrid.IsVisible = false;
            Correct_Char_Header.IsVisible = false;
            Correct_Char_ContentGrid.IsVisible = false;
            FillIn_ContentGrid.IsVisible = false;
            FillIn_Header.IsVisible = false;

            ResetAllOptionButtons();

            // Show current activity based on index
            var currentQuiz = shuffledQuestions[currentQuestionIndex];

            switch (currentActivityIndex)
            {
                case 0:
                    Select_Word_Activity(currentQuiz);
                    Select_Word_Header.IsVisible = true;
                    Select_Word_ContentGrid.IsVisible = true;
                    break;

                case 1:
                    What_You_Hear_Activity(currentQuiz);
                    What_You_Hear_Header.IsVisible = true;
                    What_You_Hear_ContentGrid.IsVisible = true;
                    break;

                case 2:
                    What_Sound_Hear_LoadQuestion(currentQuiz);
                    What_Sound_Header.IsVisible = true;
                    What_Sound_ContentGrid.IsVisible = true;
                    break;

                case 3:
                    Correct_Char_Activity(currentQuiz);
                    Correct_Char_Header.IsVisible = true;
                    Correct_Char_ContentGrid.IsVisible = true;
                    break;

                case 4:
                    FillIn_Activity(currentQuiz);
                    FillIn_Header.IsVisible = true;
                    FillIn_ContentGrid.IsVisible = true;
                    break;
            }

            // Reset selection
            selectedAnswer = string.Empty;
            CheckButton.BackgroundColor = Color.FromArgb("#E0E0E0");
        }
        #endregion

        #region ================================ Select And Match Correct Char Activity =====================

        private void MatchingPair_Activity(LetterQuizItem quiz)
            {
                // Optional: set header text dynamically
                var headerLabel = Matching_pair_Header.Children.OfType<Label>().FirstOrDefault();
                if (headerLabel != null)
                    headerLabel.Text = $"Match the correct pair for '{quiz.EnglishLetter}'";

                // Assign texts to buttons dynamically if needed
                var buttons = Matching_pair_ContentGrid.Children.OfType<Button>().ToList();

                // Example: assuming first 5 rows = 10 buttons
                if (buttons.Count >= 10)
                {
                    buttons[0].Text = quiz.ArabicOptions[0];
                    buttons[1].Text = quiz.EnglishOptions[0];
                    buttons[2].Text = quiz.ArabicOptions[1];
                    buttons[3].Text = quiz.EnglishOptions[1];
                    buttons[4].Text = quiz.ArabicOptions[2];
                    buttons[5].Text = quiz.EnglishOptions[2];
                    buttons[6].Text = quiz.ArabicOptions[3];
                    buttons[7].Text = quiz.EnglishOptions[3];
                    buttons[8].Text = quiz.ArabicOptions[4];
                    buttons[9].Text = quiz.EnglishOptions[4];
                }

                // Add click events
                foreach (var btn in buttons)
                {
                    btn.Clicked -= MatchingPairOption_Clicked;
                    btn.Clicked += MatchingPairOption_Clicked;
                }
            }
        private void MatchingPairOption_Clicked(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;
            if (clickedButton == null) return;

            // Already matched → remove color
            if (assignedColors.ContainsKey(clickedButton))
            {
                Color removeColor = assignedColors[clickedButton];
                var removeButtons = assignedColors.Where(x => x.Value == removeColor).Select(x => x.Key).ToList();

                foreach (var btn in removeButtons)
                {
                    btn.BackgroundColor = Colors.White;
                    assignedColors.Remove(btn);
                }

                // Reset selections if part of removed pair
                if (firstSelected != null && removeButtons.Contains(firstSelected))
                    firstSelected = null;
                if (secondSelected != null && removeButtons.Contains(secondSelected))
                    secondSelected = null;

                return;
            }

            // First selection
            if (firstSelected == null)
            {
                firstSelected = clickedButton;
                AssignColor(firstSelected);
            }
            // Second selection
            else if (secondSelected == null && clickedButton != firstSelected)
            {
                secondSelected = clickedButton;

                // ✅ Check if it’s a valid match
                bool isMatch = false;
                var quiz = shuffledQuestions[currentQuestionIndex];
                for (int i = 0; i < quiz.ArabicOptions.Count; i++)
                {
                    if ((quiz.ArabicOptions[i] == firstSelected.Text && quiz.EnglishOptions[i] == secondSelected.Text) ||
                        (quiz.EnglishOptions[i] == firstSelected.Text && quiz.ArabicOptions[i] == secondSelected.Text))
                    {
                        isMatch = true;
                        break;
                    }
                }

                if (isMatch)
                {
                    // Assign same color to both
                    AssignColor(secondSelected, assignedColors[firstSelected]);
                    // Lock pair
                    matchedPairs.Add(Tuple.Create(firstSelected, secondSelected));
                }
                else
                {
                    // Wrong → red flash then reset
                    secondSelected.BackgroundColor = Colors.Red;
                    firstSelected.BackgroundColor = Colors.Red;

                    Task.Delay(500).ContinueWith(_ =>
                    {
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            firstSelected.BackgroundColor = Colors.White;
                            secondSelected.BackgroundColor = Colors.White;
                        });
                    });
                }

                // Reset selections
                firstSelected = null;
                secondSelected = null;
            }
        }

        private void AssignColor(Button btn, Color? color = null)
        {
            // Agar color pass nahi hua, to nextColor list se le lo
            Color nextColor = color ?? pairColors[currentColorIndex];

            // Button aur dictionary dono me set karo
            btn.BackgroundColor = nextColor;
            assignedColors[btn] = nextColor;

            // Agar color explicitly pass nahi hua to index increment karo
            if (color == null)
            {
                currentColorIndex++;
                if (currentColorIndex >= pairColors.Count)
                    currentColorIndex = pairColors.Count - 1; // prevent overflow
            }
        }
        private void CheckMatchingPair()
            {
                if (firstSelected == null || secondSelected == null) return;

                // Current quiz
                var quiz = shuffledQuestions[currentQuestionIndex];

                // Check if the selected buttons form a valid pair
                bool isMatch = false;
                for (int i = 0; i < quiz.ArabicOptions.Count; i++)
                {
                    if ((quiz.ArabicOptions[i] == firstSelected.Text && quiz.EnglishOptions[i] == secondSelected.Text) ||
                        (quiz.EnglishOptions[i] == firstSelected.Text && quiz.ArabicOptions[i] == secondSelected.Text))
                    {
                        isMatch = true;
                        break;
                    }
                }

                if (isMatch)
                {
                    // Correct pair → lock with Green
                    firstSelected.BackgroundColor = Colors.Green;
                    secondSelected.BackgroundColor = Colors.Green;

                    // Add to matchedPairs
                    matchedPairs.Add(Tuple.Create(firstSelected, secondSelected));
                }
                else
                {
                    // Wrong pair → Red flash, then reset
                    firstSelected.BackgroundColor = Colors.Red;
                    secondSelected.BackgroundColor = Colors.Red;

                    Task.Delay(500).ContinueWith(_ =>
                    {
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            firstSelected.BackgroundColor = Colors.White;
                            secondSelected.BackgroundColor = Colors.White;
                        });
                    });
                }

                // Reset selections
                firstSelected = null;
                secondSelected = null;

                // Enable Check button if all pairs matched
                if (matchedPairs.Count == quiz.ArabicOptions.Count)
                    CheckButton.BackgroundColor = Color.FromArgb("#58CC02");
            }

        #endregion

        #region =============================== Select Correct Char Activity ================================
        private void Correct_Char_Activity(LetterQuizItem quiz)
        {
           // Set question label
           Correct_Char_Header.Children.OfType<Label>().FirstOrDefault().Text = $"Select the correct characters for '{quiz.EnglishLetter}'";

           // Set button texts dynamically (assuming 4 buttons in your XAML)
           var buttons = Correct_Char_ButtonsGrid.Children.OfType<Button>().ToList();
           if (buttons.Count >= 4)
           {
               buttons[0].Text = quiz.ArabicOptions[0];
               buttons[1].Text = quiz.ArabicOptions[1];
               buttons[2].Text = quiz.ArabicOptions[2];
               buttons[3].Text = quiz.ArabicOptions[3];
           }

           // Add click events
           foreach (var btn in buttons)
           {
               btn.Clicked -= CorrectCharOption_Clicked; // avoid duplicate
               btn.Clicked += CorrectCharOption_Clicked;
           }
         }
         private void CorrectCharOption_Clicked(object sender, EventArgs e)
            {
                var clickedButton = sender as Button;
                if (clickedButton == null) return;

                // Get inner grid that actually contains the buttons
                var innerGrid = Correct_Char_ContentGrid.Children.OfType<Grid>().FirstOrDefault();
                if (innerGrid == null) return;

                // Reset all buttons
                foreach (var btn in innerGrid.Children.OfType<Button>())
                {
                    btn.BackgroundColor = Colors.White;
                    btn.TextColor = Colors.Black;
                    btn.BorderColor = Colors.Gray; // optional, for consistent style
                }

                // Highlight clicked button
                clickedButton.BackgroundColor = Color.FromArgb("#1CB0F6");
                clickedButton.TextColor = Colors.White;

                // Set selected answer
                selectedAnswer = clickedButton.Text;

                // Enable Check button
                CheckButton.BackgroundColor = Color.FromArgb("#58CC02");
            }

        #endregion

        #region =============================== Progress Bar Animation ===================================
            private async void AnimateProgress(double targetProgress)
            {
                targetProgress = Math.Clamp(targetProgress, 0.0, 1.0);

                while (ProgressBarContainer.Width <= 0)
                    await Task.Delay(50);

                double totalWidth = ProgressBarContainer.Width;
                double targetWidth = targetProgress * totalWidth;

                ProgressFill.AbortAnimation("ProgressAnim");

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    var animation = new Animation(v =>
                    {
                        ProgressFill.WidthRequest = v;
                        ProgressFill.InvalidateMeasure();
                    },
                    ProgressFill.WidthRequest,
                    targetWidth,
                    Easing.CubicInOut);

                    animation.Commit(this, "ProgressAnim", 16, 800);
                });
            }
        #endregion

        #region =============================== Select Word Activity ====================================
            // Load Select Word activity question & options
            public void Select_Word_Activity(LetterQuizItem quiz)
            {
                SelectWord_QuestionLabel.Text = quiz.EnglishLetter;

                SelectWord_Option1.Text = quiz.ArabicOptions[0];
                SelectWord_Option2.Text = quiz.ArabicOptions[1];
                SelectWord_Option3.Text = quiz.ArabicOptions[2];
            }

            // Handle button click for Select Word activity
            private void Select_Word_Option_Clicked(object sender, EventArgs e)
            {
                var clickedButton = sender as Button;
                if (clickedButton == null) return;

                var buttons = new List<Button> { SelectWord_Option1, SelectWord_Option2, SelectWord_Option3 };

                foreach (var btn in buttons)
                {
                    btn.BackgroundColor = Colors.White;
                    btn.TextColor = Colors.Black;
                }

                clickedButton.BackgroundColor = Color.FromArgb("#1CB0F6");
                clickedButton.TextColor = Colors.White;

                // Set selected answer
                selectedAnswer = clickedButton.Text;

                // Enable Check button
                CheckButton.BackgroundColor = Color.FromArgb("#58CC02");
            }
        #endregion

        #region =============================== What You Hear Activity ==================================
            // Load What You Hear activity options
            public void What_You_Hear_Activity(LetterQuizItem quiz)
            {
                What_You_Hear_Option1.Text = quiz.ArabicOptions[0];
                What_You_Hear_Option2.Text = quiz.ArabicOptions[1];
                What_You_Hear_Option3.Text = quiz.ArabicOptions[2];
                What_You_Hear_Option4.Text = quiz.ArabicOptions[3];
            }

            // Handle What You Hear button click
            private void WhatYouHearOption_Clicked(object sender, EventArgs e)
            {
                var clickedButton = sender as Button;
                if (clickedButton == null) return;

                var buttons = new List<Button> { What_You_Hear_Option1, What_You_Hear_Option2, What_You_Hear_Option3, What_You_Hear_Option4 };

                foreach (var btn in buttons)
                {
                    btn.BackgroundColor = Colors.White;
                    btn.BorderColor = Colors.Gray;
                    btn.TextColor = Colors.Black;
                }

                clickedButton.BackgroundColor = Color.FromArgb("#1CB0F6");
                clickedButton.BorderColor = Color.FromArgb("#33AFF5");
                clickedButton.TextColor = Colors.White;

                // Set selected answer
                selectedAnswer = clickedButton.Text;

                // Enable Check button
                CheckButton.BackgroundColor = Color.FromArgb("#58CC02");
            }
    #endregion

    #region =============================== What Sound Activity =====================================
    // Load dynamic buttons for What Sound activity
    private void What_Sound_Hear_LoadQuestion(LetterQuizItem quiz)
    {
        What_SoundArabicLetterLabel.Text = quiz.ArabicLetter;
        What_Sound_OptionsFlex.Children.Clear();

        foreach (var opt in quiz.EnglishOptions)
        {
            var btn = new Button
            {
                Text = opt,
                BackgroundColor = Colors.White,
                TextColor = Colors.Black,
                BorderColor = Color.FromArgb("#E0E0E0"),
                BorderWidth = 1,
                CornerRadius = 14,
                Padding = new Thickness(14, 10),
                Margin = new Thickness(5),
                MinimumWidthRequest = 60
            };

            btn.Clicked += What_Sound_Hear_Option_Clicked;

            What_Sound_OptionsFlex.Children.Add(btn);
        }
    }


    // Handle What Sound button click
    private void What_Sound_Hear_Option_Clicked(object sender, EventArgs e)
            {
                var btn = (Button)sender;
                selectedAnswer = btn.Text;

                foreach (var child in What_Sound_OptionsFlex.Children)
                {
                    if (child is Button b)
                    {
                        b.BackgroundColor = Colors.White;
                        b.TextColor = Colors.Black;
                    }
                }

                btn.BackgroundColor = Color.FromArgb("#1CB0F6");
                btn.TextColor = Colors.White;

                CheckButton.BackgroundColor = Color.FromArgb("#58CC02");
            }
        #endregion

        #region =============================== Answer Validation ========================================
        //private bool ValidateAnswer(string answer)
        //{
        //    var currentQuiz = shuffledQuestions[currentQuestionIndex];

        //    if (Select_Word_ContentGrid.IsVisible || What_You_Hear_ContentGrid.IsVisible)
        //    {
        //        return currentQuiz.CorrectArabic == answer;
        //        shuffledQuestions[currentQuestionIndex].ActivityCount++;
        //}
        //else if (What_Sound_ContentGrid.IsVisible)
        //    {
        //        return currentQuiz.CorrectEnglish == answer;
        //}
        //    else if (Correct_Char_ContentGrid.IsVisible) // ✅ Correct Char check
        //    {
        //        // Check either Arabic or English based on button text
        //        return currentQuiz.CorrectArabic == answer || currentQuiz.CorrectEnglish == answer;
        //}
        //    else if (Matching_pair_ContentGrid.IsVisible)
        //    {
        //        if (firstSelected == null || secondSelected == null) return false;

        //        // Compare selected pair
        //        var leftText = firstSelected.Text;
        //        var rightText = secondSelected.Text;

        //        currentQuiz = shuffledQuestions[currentQuestionIndex];

        //        bool isMatch = false;

        //        // Matching logic: leftText corresponds to rightText
        //        for (int i = 0; i < currentQuiz.ArabicOptions.Count; i++)
        //        {
        //            if (currentQuiz.ArabicOptions[i] == leftText && currentQuiz.EnglishOptions[i] == rightText)
        //            {
        //                isMatch = true;
        //                break;
        //            }
        //        }

        //        // Highlight correct pair green
        //        if (isMatch)
        //        {
        //            firstSelected.BackgroundColor = Color.FromArgb("#58CC02");
        //            secondSelected.BackgroundColor = Color.FromArgb("#58CC02");
        //            matchingScore++;
        //        }
        //        else
        //        {
        //            firstSelected.BackgroundColor = Colors.Red;
        //            secondSelected.BackgroundColor = Colors.Red;
        //        }

        //        // Reset selections for next match
        //        firstSelected = null;
        //        secondSelected = null;

        //        return isMatch;
        //    }
        //    else if (FillIn_ContentGrid.IsVisible)
        //    {
        //        var quiz = shuffledQuestions[currentQuestionIndex];

        //        // If we used English options for fill, compare to CorrectEnglish, otherwise CorrectArabic
        //        if (quiz.ArabicOptions != null && quiz.ArabicOptions.Count >= 1)
        //            return quiz.CorrectArabic == answer;
        //        else
        //            return quiz.CorrectArabic == answer;
        //    }
        //    return false;
        //}


        private bool ValidateAnswer(string answer)
        {
            var currentQuiz = shuffledQuestions[currentQuestionIndex];
            bool isCorrect = false;

            // ---------------------- SELECT WORD / WHAT YOU HEAR ----------------------
            if (Select_Word_ContentGrid.IsVisible || What_You_Hear_ContentGrid.IsVisible)
            {
                isCorrect = currentQuiz.CorrectArabic == answer;
            }

            // ---------------------- WHAT SOUND ----------------------
            else if (What_Sound_ContentGrid.IsVisible)
            {
                isCorrect = currentQuiz.CorrectEnglish == answer;
            }

            // ---------------------- CORRECT CHAR ----------------------
            else if (Correct_Char_ContentGrid.IsVisible)
            {
                isCorrect = currentQuiz.CorrectArabic == answer || currentQuiz.CorrectEnglish == answer;
            }

            // ---------------------- MATCHING PAIR ----------------------
            else if (Matching_pair_ContentGrid.IsVisible)
            {
                if (firstSelected == null || secondSelected == null)
                    return false;

                var leftText = firstSelected.Text;
                var rightText = secondSelected.Text;

                isCorrect = false;

                for (int i = 0; i < currentQuiz.ArabicOptions.Count; i++)
                {
                    if (currentQuiz.ArabicOptions[i] == leftText &&
                        currentQuiz.EnglishOptions[i] == rightText)
                    {
                        isCorrect = true;
                        break;
                    }
                }

                // Color change
                firstSelected.BackgroundColor = isCorrect ? Color.FromArgb("#58CC02") : Colors.Red;
                secondSelected.BackgroundColor = isCorrect ? Color.FromArgb("#58CC02") : Colors.Red;

                // Clear selection
                firstSelected = null;
                secondSelected = null;
            }

            // ---------------------- FILL IN THE BLANK ----------------------
            else if (FillIn_ContentGrid.IsVisible)
            {
                isCorrect = currentQuiz.CorrectArabic == answer;
            }


            // ---------------------- ACTIVITY COUNT UPDATE ----------------------
            shuffledQuestions[currentQuestionIndex].ActivityCount++;
        
            return isCorrect;
        }
        private async void CheckButton_Clicked(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(selectedAnswer)) return;

                if (Matching_pair_ContentGrid.IsVisible)
                {
                    bool isMatch = ValidateAnswer(selectedAnswer);
                    if (isMatch)
                    {
                        // show correct
                    }
                    else
                    {
                        // show wrong
                    }

                    // Check if all matches done
                    var totalPairs = Matching_pair_ContentGrid.Children.OfType<Button>().Count() / 2;
                    if (matchingScore >= totalPairs)
                    {
                        DisplayAlert("Done!", "You matched all pairs!", "OK");
                        matchingScore = 0;
                        LoadNextQuestion();
                    }
                }
            if (!isAnswerChecked)
            {
                bool isCorrect = ValidateAnswer(selectedAnswer);

                if (isCorrect)
                {
                    // List of positive feedback boxes
                    var positiveBoxes = new List<Frame> { nicelydoneBox, excellentBox, AwesomeBox, AmazingBox };

                    // Pick one randomly
                    var random = new Random();
                    var boxToShow = positiveBoxes[random.Next(positiveBoxes.Count)];

                    boxToShow.IsVisible = true;
                    await boxToShow.FadeTo(0, 800);
                    boxToShow.Opacity = 1;
                }
                else
                {
                    WorngBox.IsVisible = true;
                    await WorngBox.FadeTo(0, 800);
                    WorngBox.Opacity = 1;
                }

                CheckButton.Text = "Continue";
                isAnswerChecked = true;
            }
            else
            {
                // Hide all feedback boxes
                CorrectBox.IsVisible = false;
                WorngBox.IsVisible = false;
                nicelydoneBox.IsVisible = false;
                excellentBox.IsVisible = false;
                AwesomeBox.IsVisible = false;
                AmazingBox.IsVisible = false;

                UpdateProgress();
                LoadNextQuestion();
                CheckButton.Text = "Check";
                isAnswerChecked = false;
            }
        }
    #endregion

    #region =============================== Fill in The Blank Activity=================================

    //     private void FillIn_Activity(LetterQuizItem quiz)
    //{
    //    // Header label (optional dynamic)
    //    var headerLabel = FillIn_Header.Children.OfType<Label>().FirstOrDefault();
    //    if (headerLabel != null)
    //        headerLabel.Text = $"Fill in the blank for '{quiz.EnglishLetter}'";

    //    // Determine sentence text - prefer a FillSentence property if present, otherwise a default template
    //    string sentence = null;
    //    // try to use a 'FillSentence' property if your model has it
    //    var prop = typeof(LetterQuizItem).GetProperty("FillSentence");
    //    if (prop != null)
    //    {
    //        var val = prop.GetValue(quiz) as string;
    //        if (!string.IsNullOrWhiteSpace(val))
    //            sentence = val;
    //    }

    //    // fallback: create a template sentence using EnglishLetter
    //    if (string.IsNullOrWhiteSpace(sentence))
    //    {
    //        sentence = $"Select the missing word for '{quiz.EnglishLetter}': ___ {quiz.EnglishLetter}";
    //    }

    //    FillIn_SentenceLabel.Text = sentence;

    //    // Choose options source: prefer EnglishOptions, otherwise ArabicOptions
    //    var options = (quiz.ArabicOptions != null && quiz.ArabicOptions.Count >= 3)
    //                    ? quiz.ArabicOptions.Take(3).ToList()
    //                    : quiz.EnglishOptions.Take(3).ToList();

    //    // If fewer than 3 options exist, pad with whatever is available
    //    while (options.Count < 3)
    //    {
    //        options.Add(string.Empty);
    //    }

    //    Fill_Option1.Text = options[0];
    //    Fill_Option2.Text = options[1];
    //    Fill_Option3.Text = options[2];

    //    // Reset visuals
    //    Fill_Option1.BackgroundColor = Colors.White; Fill_Option1.TextColor = Colors.Black;
    //    Fill_Option2.BackgroundColor = Colors.White; Fill_Option2.TextColor = Colors.Black;
    //    Fill_Option3.BackgroundColor = Colors.White; Fill_Option3.TextColor = Colors.Black;
    //}


    //     private void FillIn_Option_Clicked(object sender, EventArgs e)
    //{
    //    var clickedButton = sender as Button;
    //    if (clickedButton == null) return;

    //    // reset other options
    //    var opts = new List<Button> { Fill_Option1, Fill_Option2, Fill_Option3 };
    //    foreach (var b in opts)
    //    {
    //        b.BackgroundColor = Colors.White;
    //        b.TextColor = Colors.Black;
    //    }

    //    // highlight selected
    //    clickedButton.BackgroundColor = Color.FromArgb("#1CB0F6");
    //    clickedButton.TextColor = Colors.White;

    //    // set selectedAnswer (we'll validate against quiz)
    //    selectedAnswer = clickedButton.Text;

    //    // enable Check button
    //    CheckButton.BackgroundColor = Color.FromArgb("#58CC02");
    //}

    private void FillIn_Option_Clicked(object sender, EventArgs e)
    {
        if (sender is not Button clickedButton)
            return;

        // reset all buttons
        foreach (var child in Fill_OptionsFlex.Children)
        {
            if (child is Button b)
            {
                b.BackgroundColor = Colors.White;
                b.TextColor = Colors.Black;
            }
        }

        // highlight selected button
        clickedButton.BackgroundColor = Color.FromArgb("#1CB0F6");
        clickedButton.TextColor = Colors.White;

        // store selected answer
        selectedAnswer = clickedButton.Text;

        // enable "Check" button
        CheckButton.BackgroundColor = Color.FromArgb("#58CC02");
    }

    private void FillIn_Activity(LetterQuizItem quiz)
    {
        // Header update
        var headerLabel = FillIn_Header.Children.OfType<Label>().FirstOrDefault();
        if (headerLabel != null)
            headerLabel.Text = $"Fill in the blank for '{quiz.EnglishLetter}'";

        // Direct default sentence (no FillSentence)
        string sentence = $"Select the missing word for '{quiz.EnglishLetter}': ___ {quiz.EnglishLetter}";
        FillIn_SentenceLabel.Text = sentence;

        // Choose options
        var options = (quiz.ArabicOptions != null && quiz.ArabicOptions.Count >= 3)
                        ? quiz.ArabicOptions.Take(3).ToList()
                        : quiz.EnglishOptions.Take(3).ToList();

        while (options.Count < 3)
            options.Add("");

        // Clear old UI
        Fill_OptionsFlex.Children.Clear();

        // Create responsive option buttons
        foreach (var opt in options)
        {
            var btn = new Button
            {
                Text = opt,
                BackgroundColor = Colors.White,
                BorderColor = Color.FromArgb("#5480C0"),
                BorderWidth = 2,
                TextColor = Colors.Black,
                CornerRadius = 10,
                Padding = new Thickness(14, 10),
                Margin = new Thickness(5),
                MinimumWidthRequest = 60,
            };

            btn.Clicked += FillIn_Option_Clicked;
            Fill_OptionsFlex.Children.Add(btn);
        }

        selectedAnswer = null;
    }
    #endregion

    #region =============================== Progress Update ==========================================
    private void UpdateProgress()
            {
                var category = SpecialLetterRepository.GetCategoryById(1);
                int totalQuestions = category.QuizItems.Count;

                int totalSteps = totalQuestions * 3;
                int currentStep = currentQuestionIndex * 3 + currentActivityIndex + 1;

                double progress = (double)currentStep / totalSteps;
                AnimateProgress(progress);
            }
        #endregion

        #region =============================== Next Question Logic =====================================
            private void LoadNextQuestion()
            {
                currentActivityIndex++;

                if (currentActivityIndex > 4)
                {
                    currentActivityIndex = 0;
                    currentQuestionIndex++;

                    if (currentQuestionIndex >= shuffledQuestions.Count)
                    {
                        DisplayAlert("Done", "You finished all letters!", "OK");
                        return;
                    }
                }

                selectedAnswer = string.Empty;
                CheckButton.BackgroundColor = Color.FromArgb("#E0E0E0");

                ShowCurrentActivity();
            }
        #endregion

        #region =============================== Reset Option Buttons ====================================
            private void ResetAllOptionButtons()
            {
                // Reset Select Word buttons
                var selectWordButtons = new List<Button> { SelectWord_Option1, SelectWord_Option2, SelectWord_Option3 };
                foreach (var btn in selectWordButtons)
                {
                    btn.BackgroundColor = Colors.White;
                    btn.TextColor = Colors.Black;
                }

                // Reset What You Hear buttons
                var whatYouHearButtons = new List<Button> { What_You_Hear_Option1, What_You_Hear_Option2, What_You_Hear_Option3, What_You_Hear_Option4 };
                foreach (var btn in whatYouHearButtons)
                {
                    btn.BackgroundColor = Colors.White;
                    btn.BorderColor = Colors.Gray;
                    btn.TextColor = Colors.Black;
                }

                // Reset What Sound buttons (dynamic)
                foreach (var child in What_Sound_OptionsFlex.Children)
                {
                    if (child is Button b)
                    {
                        b.BackgroundColor = Colors.White;
                        b.TextColor = Colors.Black;
                    }
                }
                var innerGrid = Correct_Char_ContentGrid.Children.OfType<Grid>().FirstOrDefault();
                if (innerGrid != null)
                {
                    foreach (var btn in innerGrid.Children.OfType<Button>())
                    {
                        btn.BackgroundColor = Colors.White;
                        btn.TextColor = Colors.Black;
                        btn.BorderColor = Colors.Gray; // optional
                    }
                }
                var matchingPairButtons = Matching_pair_ContentGrid.Children.OfType<Button>();
                foreach (var btn in matchingPairButtons)
                {
                    btn.BackgroundColor = Colors.White;
                    btn.TextColor = Colors.Black;
                    btn.BorderColor = Colors.Gray;
                }
            }
    #endregion

    //private async void PlayVoice(object sender, EventArgs e)
    //{

    //var currentQuiz = shuffledQuestions[currentQuestionIndex];
    //await TextToSpeech.SpeakAsync("Hello Candidate, how are you?");
    //}

    private async void PlayVoice(object sender, EventArgs e)
    {
        var currentQuiz = shuffledQuestions[currentQuestionIndex];

        await TextToSpeech.SpeakAsync(currentQuiz.ArabicLetter);


        var locales = await TextToSpeech.GetLocalesAsync();
        var arabic = locales.FirstOrDefault(x => x.Language.Contains("ar"));

        if (arabic == null)
        {
            //await DisplayAlert("Error", "Arabic TTS not available on device.", "OK");
            return;
        }

        await TextToSpeech.SpeakAsync("و", new SpeechOptions
        {
            Locale = arabic
        });
    }
}
