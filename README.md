# Test.Repository.Backed
個人開発テスト用リポジトリ
/プロジェクト名
├── /Controllers          // コントローラー
├── /Models               // モデル
│   ├── /Entities         // エンティティ（DBテーブルに対応）
│   └── /DTOs             // データ転送オブジェクト（APIの入出力用）
│   
├── /UseCases             // ユースケース（ビジネスロジックのエントリーポイント）
├── /Interactors          // インタラクター（ユースケースを具体化したクラス）
├── /Repositories         // データアクセスのためのリポジトリ
├── /Migrations           // データベースマイグレーション
├── /Configurations       // アプリケーション設定やカスタム設定
├── /Middlewares          // カスタムミドルウェア
├── /Tests                // 単体テストや統合テスト
└── Program.cs            // エントリポイント
