mergeInto(LibraryManager.library, {
  GetRecord: function () {
    player.getData().then((stats) => {
      console.log(stats);
      console.log(Object.keys(stats).length);

      if (Object.keys(stats).length != 0) {
        console.log(player.getData(record));
        console.log(stats["record"]);
        console.log(stats[record]);

        myGameInstance.SendMessage(
          "Yandex",
          "InitialRecord",
          stats[record] // тут исправить на что-то такое player.getStats("record")
        );
      } else {
        myGameInstance.SendMessage("Yandex", "InitialRecord", "0");
      }
    });
  },
  SaveGame: function (newRecord) {
    player.setData({
      record: newRecord,
    });

    player.getData().then((stats) => {
      console.log("SAVEGAME: ");
      console.log(stats);
    });
  },
});
