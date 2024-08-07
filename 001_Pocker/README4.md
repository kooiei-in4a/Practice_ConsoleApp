﻿## ポーカーゲームアプリケーション課題仕様書

### 1. 概要
この課題では、Javaを使用してコンソールアプリケーションとして動作する5カードドローポーカーゲームを実装します。プロジェクトは段階的に難易度が上がる3つのフェーズに分かれており、各フェーズで新しい要素が追加されます。

### 2. プロジェクトフェーズ

#### フェーズ1: 基本実装
- 基本的なポーカーゲームの実装
- プレイヤーvsコンピュータの対戦
- 手札の評価と勝敗判定

#### フェーズ2: 拡張機能
- マルチプレイヤー対応（2-4人）
- 統計情報の記録と表示
- 簡単なAIの実装

#### フェーズ3: 高度な機能
- 複数のポーカーバリエーションの実装（テキサスホールデム等）
- 高度なAIの実装（機械学習の基本を利用）
- ネットワーク対戦機能

### 3. 詳細仕様（フェーズ1）

#### 3.1 ゲームルール
- 使用するポーカーのルールは「5カードドロー」です。
- プレイヤーとコンピュータはそれぞれ5枚のカードを持ちます。
- プレイヤーは1回だけカードを交換できます。
- 最終的な手札の強さを比較し、勝者を決定します。

#### 3.2 要求機能
- ゲーム開始時にプレイヤーに名前を入力させます。
- トランプのデッキをシャッフルし、プレイヤーとコンピュータに5枚ずつカードを配ります。
- プレイヤーの手札をコンソールに表示します。
- カードは「2♥」のように表示します（Unicode文字を使用）。
- プレイヤーは1回だけ任意の枚数のカードを交換できます。
- 交換するカードの番号を入力させ、新しいカードを配ります。
- コンピュータは現在の手札を評価し、最適な戦略でカードを交換します。
- 最終的な手札の強さを比較し、勝者を決定します。
- 両者の手札と役、勝者の名前を表示します。
- 不正な入力に対してエラーメッセージを表示し、再入力を促します。
- デッキのカードが不足した場合の処理を実装します。
- ゲーム終了後、プレイヤーに再プレイの選択肢を提供します。

#### 3.3 クラス設計
- `Card`クラス：カードのスートとランクを管理
- `Deck`クラス：カードのデッキを管理
- `Hand`クラス：手札を管理
- `Player`クラス：プレイヤーの名前と手札を管理
- `ComputerPlayer`クラス（Playerクラスを継承）：コンピュータの動作を管理
- `PokerGame`クラス：ゲーム全体の流れを管理
- `HandEvaluator`クラス：手札の評価ロジックを管理
- `GameSettings`クラス：ゲーム設定の管理
- `Statistics`クラス：統計情報の管理
- `FileManager`クラス：ファイル操作の管理

### 4. 実装要件

#### 4.1 コーディング規約
- Google Java Style Guideに準拠してください。
- チェックスタイルを使用して規約準拠を確認してください。

#### 4.2 パフォーマンスとメモリ管理
- 大規模なデータセット（1万回以上のゲームプレイ）でもスムーズに動作するようにしてください。
- メモリリークを防ぐため、適切なリソース管理を行ってください。

#### 4.3 セキュリティ
- 入力値の検証とサニタイズを徹底してください。
- ファイル操作時にはセキュアな方法を使用してください。

#### 4.4 国際化対応
- すべての表示テキストをプロパティファイルで管理し、多言語対応を可能にしてください。
- 日本語と英語のローカライズを実装してください。

#### 4.5 テスト
- JUnitを使用して単体テストを作成してください（コードカバレッジ80%以上）。
- 統合テストを実装し、主要なユースケースをカバーしてください。
- パフォーマンステストを実装し、大規模データセットでの動作を確認してください。

### 5. 開発プロセス

#### 5.1 バージョン管理
- Gitを使用し、適切なブランチ戦略を採用してください（例：GitFlow）。
- コミットメッセージは明確で一貫性のあるフォーマットを使用してください。

#### 5.2 CI/CDパイプライン
- GitHubActionsを使用してCI/CDパイプラインを構築してください。
- ビルド、テスト、静的コード解析を自動化してください。

#### 5.3 コードレビュー
- プルリクエストを使用してコードレビューを行ってください。
- レビューチェックリストを作成し、一貫したレビュー基準を設けてください。

#### 5.4 ドキュメンテーション
- JavaDocを使用して全てのパブリックメソッドにドキュメントを付けてください。
- アーキテクチャ設計書を作成してください（UMLダイアグラムを含む）。
- ユーザーマニュアルを作成してください。

### 6. プロジェクト管理
- GitHub Projectsを使用してタスク管理を行ってください。
- マイルストーンを設定し、各フェーズの進捗を管理してください。

### 7. 提出物
1. GitHubリポジトリ（以下を含むこと）
   - ソースコード
   - テストコード
   - README.md（プロジェクト概要、セットアップ手順、使用方法）
   - CONTRIBUTING.md（コントリビューションガイドライン）
   - LICENSE（オープンソースライセンス）
   - .gitignore
   - CI/CD設定ファイル
2. アーキテクチャ設計書（PDF）
3. ユーザーマニュアル（PDF）
4. プロジェクト報告書（開発プロセス、苦労した点、学んだこと等を記述）

### 8. 評価基準
- 機能の完全性と正確性：40%
- コード品質とアーキテクチャ：20%
- テストの充実度：15%
- パフォーマンスとセキュリティ：10%
- ドキュメンテーションの質：10%
- 開発プロセスの適切さ：5%

### 9. 追加チャレンジ（オプション）
- デザインパターンを3つ以上適用し、その理由と利点を説明してください。
- コマンドラインオプションを実装し、様々なゲーム設定を可能にしてください。
- ロギング機能を実装し、詳細なゲームログを生成してください。

### 10. サポートとフィードバック
- 週1回のオンラインQ&Aセッションを設けます。
- 各フェーズ終了時に、コードレビューとフィードバックを提供します。

この仕様書に従って実装することで、実践的なソフトウェア開発スキルを身につけることができます。質問や不明点がある場合は、遠慮なくお問い合わせください。