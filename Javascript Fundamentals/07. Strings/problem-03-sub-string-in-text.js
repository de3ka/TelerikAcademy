function SubstringCount(args) {
    var wordToSearch=String(args[0]).toLowerCase();
    var text=String(args[1]).toLowerCase();
    var counter=0;

    var index=text.indexOf(wordToSearch);
    while(index>=0){
        counter++;
        index=text.indexOf(wordToSearch,index+1);
    }
    console.log(counter);
}
