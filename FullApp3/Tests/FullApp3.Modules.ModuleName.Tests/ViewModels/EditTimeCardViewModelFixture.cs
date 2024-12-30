using FullApp3.Modules.TimeCard.ViewModels;
using FullApp3.Services.Interfaces;
using Moq;
using Prism.Regions;
using Xunit;
using System;
using System.Linq;

namespace FullApp3.Modules.TimeCard.Tests.ViewModels
{
    public class EditTimeCardViewModelFixture
    {
        Mock<IMessageService> _messageServiceMock;
        Mock<IRegionManager> _regionManagerMock;

        public EditTimeCardViewModelFixture()
        {
            _messageServiceMock = new Mock<IMessageService>();
            _regionManagerMock = new Mock<IRegionManager>();
        }

        [Fact]
        public void SelectedWorkDate_ShouldInitializeWithCurrentDate()
        {
            // テスト観点: SelectedWorkDateがシステム日付で初期化されていることを確認する
            // Arrange
            var vm = new EditTimeCardViewModel(_regionManagerMock.Object, _messageServiceMock.Object);

            // Act & Assert
            Assert.Equal(DateTime.Now.Date, vm.SelectedWorkDate.Date);
        }

        [Fact]
        public void SelectedStartTime_ShouldInitializeWithFirstOption()
        {
            // テスト観点: SelectedStartTimeがStartTimeOptionsの最初の要素で初期化されていることを確認する
            // Arrange
            var vm = new EditTimeCardViewModel(_regionManagerMock.Object, _messageServiceMock.Object);

            // Act & Assert
            Assert.Equal(vm.StartTimeOptions.First(), vm.SelectedStartTime);
        }

        [Fact]
        public void SelectedEndTime_ShouldInitializeWithFirstOption()
        {
            // テスト観点: SelectedEndTimeがEndTimeOptionsの最初の要素で初期化されていることを確認する
            // Arrange
            var vm = new EditTimeCardViewModel(_regionManagerMock.Object, _messageServiceMock.Object);

            // Act & Assert
            Assert.Equal(vm.EndTimeOptions.First(), vm.SelectedEndTime);
        }

        [Fact]
        public void SelectedBreakTime_ShouldInitializeWithFirstOption()
        {
            // テスト観点: SelectedBreakTimeがBreakTimeOptionsの最初の要素で初期化されていることを確認する
            // Arrange
            var vm = new EditTimeCardViewModel(_regionManagerMock.Object, _messageServiceMock.Object);

            // Act & Assert
            Assert.Equal(vm.BreakTimeOptions.First(), vm.SelectedBreakTime);
        }

        [Fact]
        public void WorkType_ShouldInitializeWithDefault()
        {
            // テスト観点: WorkTypeが"在宅"で初期化されていることを確認する
            // Arrange
            var vm = new EditTimeCardViewModel(_regionManagerMock.Object, _messageServiceMock.Object);

            // Act & Assert
            Assert.Equal("在宅", vm.WorkType);
        }

        [Fact]
        public void SaveTimeCardCommand_ShouldExecuteCorrectly()
        {
            // テスト観点: SaveTimeCardCommandが正しく実行されることを確認する
            // Arrange
            var vm = new EditTimeCardViewModel(_regionManagerMock.Object, _messageServiceMock.Object);

            // Act & Assert
            Assert.True(vm.SaveTimeCardCommand.CanExecute(null));
            // Additional logic to verify command execution can be added here
        }

        [Fact]
        public void SelectedStartTime_ShouldThrowExceptionForInvalidFormat()
        {
            // テスト観点: SelectedStartTimeに不正な形式の値を設定した場合に例外がスローされることを確認する
            // Arrange
            var vm = new EditTimeCardViewModel(_regionManagerMock.Object, _messageServiceMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => vm.SelectedStartTime = "invalid");
        }

        [Fact]
        public void PropertyChanged_ShouldFireOnSelectedWorkDateChange()
        {
            // テスト観点: SelectedWorkDateが変更されたときにPropertyChangedイベントが発生することを確認する
            // Arrange
            var vm = new EditTimeCardViewModel(_regionManagerMock.Object, _messageServiceMock.Object);

            // Act & Assert
            Assert.PropertyChanged(vm, nameof(vm.SelectedWorkDate), () => vm.SelectedWorkDate = DateTime.Now.AddDays(1));
        }

        // Additional tests for other properties and business logic can be added here
    }
}
