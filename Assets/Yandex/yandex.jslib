mergeInto(LibraryManager.library, {
  InitGame: function () {
    let ysdkCopy;
    let playerCopy;

    YaGames.init().then((_sdk) => {
      ysdkCopy = _sdk;

      console.log(ysdkCopy);

      ysdkCopy.getPlayer().then((_player) => {
        playerCopy = _player;

        playerCopy.getData().then((stats) => {
          console.log(stats["record"]);
          console.log(stats["record"]);
          console.log(stats["record"]);
          console.log(stats["record"]);
          console.log(stats["record"]);
          console.log(stats["record"]);
          console.log(stats["record"]);
          console.log(stats["record"]);

          if (Object.keys(stats).length != 0) {
            // var obj = JSON.parse(stats["record"]);
            // Отправка данных в unity

            const myJSON = JSON.stringify(stats);
            myGameInstance.SendMessage("Yandex", "Load", myJSON);

            // myGameInstance.SendMessage(
            //   "Yandex",
            //   "SetData",
            //   stats["record"].toString()
            // );
          }
        });
      });
    });
  },
  SaveGame: function (newRecord) {
    // var obj = UTF8ToString(newRecord);

    // console.log("obj: " + obj);
    // var dateString = UTF8ToString(date);
    var myobj = JSON.parse(newRecord);

    console.log("myobj: " + myobj);

    player.setData({
      record: myobj,
    });

    // player.getData().then((stats) => {
    //   console.log("SAVEGAME: ");
    //   // console.log(stats);
    // });
  },
});
