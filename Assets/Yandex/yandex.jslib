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

          myGameInstance.SendMessage(
            "Yandex",
            "SetData",
            stats["record"].toString()
          );
          myGameInstance.SendMessage("Yandex", "SetData", stats["record"]);
        });
      });
    });
  },
  GetRecord: function () {
    player.getData().then((stats) => {
      if (Object.keys(stats).length != 0) {
        myGameInstance.SendMessage(
          "Yandex",
          "InitialRecord",
          JSON.parse(stats["record"])
        );
      } else {
        myGameInstance.SendMessage("Yandex", "SetData", "0");
      }
    });
  },
  SaveGame: function (newRecord) {
    var obj = JSON.stringify(newRecord);

    player.setData({
      record: obj,
    });

    player.getData().then((stats) => {
      console.log("SAVEGAME: ");
      // console.log(stats);
    });
  },
});
