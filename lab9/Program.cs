using lab9;


Auction auction = new Auction();

auction.AddObserver(new Observer("Participant 1", auction));
auction.AddObserver(new Observer("Participant 2", auction));
auction.AddObserver(new Observer("Participant 3", auction));

auction.StartAuction();
