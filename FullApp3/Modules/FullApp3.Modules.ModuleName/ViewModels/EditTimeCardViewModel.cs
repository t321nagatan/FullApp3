using FullApp3.Core.Mvvm;
using FullApp3.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Windows.Input;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FullApp3.Modules.TimeCard.ViewModels
{
    public class EditTimeCardViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private string _selectedStartTime;
        private string _selectedEndTime;
        private DateTime _selectedWorkDate;
        private List<string> _startTimeOptions;
        private List<string> _endTimeOptions;
        private List<string> _breakTimeOptions;
        private string _selectedBreakTime;
        private string _workType;
        private string _startText;
        private string _endText;

        public DateTime SelectedWorkDate
        {
            get => _selectedWorkDate;
            set
            {
                SetProperty(ref _selectedWorkDate, value);
                createStartText();
                createEndText();
            }
        }

        public List<string> StartTimeOptions
        {
            get => _startTimeOptions;
            set => SetProperty(ref _startTimeOptions, value);
        }
        public string SelectedStartTime
        {
            get => _selectedStartTime;
            set
            {
                if (!string.IsNullOrEmpty(value) && !Regex.IsMatch(value, @"^[1-9]?\d:[1-9]?\d$"))
                {
                    throw new ArgumentException("SelectedStartTime must be in the format mm:dd", nameof(value));
                }
                SetProperty(ref _selectedStartTime, value);
                createStartText();
                createEndText();
            }
        }

        public List<string> EndTimeOptions
        {
            get => _endTimeOptions;
            set => SetProperty(ref _endTimeOptions, value);
        }
        public string SelectedEndTime
        {
            get => _selectedEndTime;
            set
            {
                SetProperty(ref _selectedEndTime, value);
                createStartText();
                createEndText();
            }
        }

        public List<string> BreakTimeOptions
        {
            get => _breakTimeOptions;
            set => SetProperty(ref _breakTimeOptions, value);
        }
        public string SelectedBreakTime
        {
            get => _selectedBreakTime;
            set
            {
                SetProperty(ref _selectedBreakTime, value);
                createStartText();
                createEndText();
            }
        }

        public string WorkType
        {
            get => _workType;
            set
            {
                SetProperty(ref _workType, value);
                createStartText();
                createEndText();
            }
        }

        public string StartText
        {
            get => _startText;
            set => SetProperty(ref _startText, value);
        }
        public string EndText
        {
            get => _endText;
            set => SetProperty(ref _endText, value);
        }

        public ICommand SaveTimeCardCommand { get; }

        #region コンストラクタ
        public EditTimeCardViewModel(IRegionManager regionManager, IMessageService messageService) :
    base(regionManager)
        {
            Message = messageService.GetMessage();

            // システム日付をWorkDateに設定
            SelectedWorkDate = DateTime.Now;

            // 時間オプションの初期化
            StartTimeOptions = new List<string> { "8:50", "9:00", "11:00", "12:00", "13:00" };
            EndTimeOptions = new List<string> { "18:00", "19:00", "20:00", "21:00" };
            BreakTimeOptions = new List<string> { "1:10", "1:30" };

            // 開始時間の初期値を設定
            SelectedStartTime = StartTimeOptions.First();
            // 終了時間の初期値を設定
            SelectedEndTime = EndTimeOptions.First();
            // 終了時間の初期値を設定
            SelectedBreakTime = BreakTimeOptions.First();
            // 初期勤務区分を設定
            WorkType = "在宅";

            // SaveTimeCardCommandの初期化
            SaveTimeCardCommand = new DelegateCommand(ExecuteSaveTimeCard, CanExecuteSaveTimeCard)
                                  .ObservesProperty(() => SelectedStartTime)
                                  .ObservesProperty(() => SelectedEndTime);
        }
        #endregion

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }



        public void createStartText()
        {
            StartText = createCopyText(new[] { "出勤" });
        }
        public void createEndText()
        {
            EndText = createCopyText(new[] { "退勤" });
        }
        public string createCopyText(string[] value)
        {
            string text = "";
            text += $"{SelectedWorkDate.ToString("M/d")} {value[0]} ({WorkType})\n";
            text += $"開始　{SelectedStartTime}\n";
            text += $"終了　{SelectedEndTime}\n";
            text += $"休憩　{SelectedBreakTime}\n";
            return text;
        }

        private void ExecuteSaveTimeCard()
        {
            // タイムカードを保存する処理をここに記述
        }

        private bool CanExecuteSaveTimeCard()
        {
            return TimeSpan.Parse(SelectedEndTime) > TimeSpan.Parse(SelectedStartTime);
        }
    }

}
