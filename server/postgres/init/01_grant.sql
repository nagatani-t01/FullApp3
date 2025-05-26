-- 作成したDBに接続
\c test_db;

-- すべてのテーブルへ権限追加
GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO psuser;

-- すべてのシーケンスへ権限追加
GRANT USAGE ON ALL SEQUENCES IN SCHEMA public TO psuser;
