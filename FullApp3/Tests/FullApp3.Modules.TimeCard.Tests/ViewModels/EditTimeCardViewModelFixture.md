# EditTimeCardViewModel テスト観点

## プロパティの初期化
- `SelectedWorkDate` がシステム日付で初期化されていることを確認する。
- `SelectedStartTime` が `StartTimeOptions` の最初の要素で初期化されていることを確認する。
- `SelectedEndTime` が `EndTimeOptions` の最初の要素で初期化されていることを確認する。
- `SelectedBreakTime` が `BreakTimeOptions` の最初の要素で初期化されていることを確認する。
- `WorkType` が "在宅" で初期化されていることを確認する。

## プロパティのバインディング
- `SelectedWorkDate` プロパティが正しくバインドされていることを確認する。
- `SelectedStartTime` プロパティが正しくバインドされていることを確認する。
- `SelectedEndTime` プロパティが正しくバインドされていることを確認する。
- `SelectedBreakTime` プロパティが正しくバインドされていることを確認する。
- `WorkType` プロパティが正しくバインドされていることを確認する。

## コマンドの動作
- `SaveTimeCardCommand` が正しく実行されることを確認する。
- `SaveTimeCardCommand` の実行条件が正しく設定されていることを確認する。

## 入力検証
- `SelectedStartTime` に `mm:d0` 形式以外の値を設定しようとした場合に例外がスローされることを確認する。
- `SelectedEndTime` に `mm:d0` 形式以外の値を設定しようとした場合に例外がスローされることを確認する。

## プロパティ変更通知
- `SelectedWorkDate` が変更されたときに、`PropertyChanged` イベントが正しく発生することを確認する。
- `SelectedStartTime` が変更されたときに、`PropertyChanged` イベントが正しく発生することを確認する。
- `SelectedEndTime` が変更されたときに、`PropertyChanged` イベントが正しく発生することを確認する。
- `SelectedBreakTime` が変更されたときに、`PropertyChanged` イベントが正しく発生することを確認する。
- `WorkType` が変更されたときに、`PropertyChanged` イベントが正しく発生することを確認する。

## ビジネスロジック
- `TotalWorkTime` が正しく計算されることを確認する。
- `IsHoliday` が正しく設定されることを確認する。

## エッジケース
- `StartTime` や `EndTime` が境界値（例: `00:d0`, `23:d0`）で正しく動作することを確認する。
- `BreakTimeOptions` が空の場合の動作を確認する。

## UIとの連携
- UI上での操作がViewModelのプロパティに正しく反映されることを確認する。
- UI上での操作がコマンドの実行に正しく反映されることを確認する。
