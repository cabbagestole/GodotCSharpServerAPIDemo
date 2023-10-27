# GodotCSharpServerAPIDemo
(Godot4.1) A study of calling serverAP from C#.


ueshitaさんの作成したベンチマーク(GDScript, GDExtention(C++))のノード版とServerAPI版)はこちら
https://github.com/ueshita/GDExtensionDemo

こちらに影響をうけてC#でも同様に動作するノード版とServerAPI版の移植をしました。

## ビルド関係
Godot4.1.2のmono版を使ってください。C#のコードに対して一度ビルドをかける必要があります。

右上にBuildボタンが現れない時は適当なC#スクリプト(Test.cs等)を新規生成してください。

エディタがC#である事を再認知してBuildボタンが現れます。

## シーン(tscn)
sprite_scence_cs.tscn ... ノード版

sprite_server_cs.tscn ... サーバAPI版

何れかをプロジェクトの基点シーンとして選択してください。

## スクリプト(C#)
同じ構成になるよう、以下の対応を取っています。

SpriteCS.cs　→　sprite.gd

SpriteSceneCs.cs　→sprite_scene_gd.gd

SpriteServerCs.cs　→sprite_server_gd.gd


## その他
main.gdでFPSの上限をセットしています。PC が火を噴かないよう、実行環境に応じてFPS上限を修正してください。

スプライトを格納するコレクションspritesですが、Godot.Collections.ArrayではなくC#のSystem.Collections.Generic.Listを使ってます。

GodotのArrayはC#側コードから呼び出して要素数を取得しようとすると0が返る不具合の回避策ですが、そこまで厳密に合わせる必要もないでしようからC#のListで代用しています。




