using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;

using System.Xml.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime;
using System.IO.Compression;
using System.Collections.Generic;
using MonoTouch.CoreAnimation;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Serialization;
using System.IO;
using TSMiniWebBrowser;
using MonoTouch.ExternalAccessory;
using System.Linq;
using MonoTouch.EventKit;
using GoogleAdMobAds;
using Xamarin.Media;
using System.Runtime.Serialization;
using Xamarin.Auth;
using System.Net;
using MonoTouch.AudioToolbox;
using MonoTouch.AVFoundation;
using MonoTouch.ObjCRuntime;
using System.Globalization;
using System.Reflection;

namespace xxx
{
	public class ZoomingUIImageView : UIImageView
	{
		public override UIImage Image {get; set;}
		public ZoomingUIImageView(UIImage image) : base(image)
		{
			Image = image;
		}
	}

	public partial class xxxViewController : UIViewController
	{
		CreateEventEditViewDelegate eventControllerDelegate;
		bool IsAuthenticated = false;

		public xxxViewController () : base ("xxxViewController", null)
		{
			
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.

		}



		public override async void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			UITextView tv = new UITextView();

			Title = "Hi There!";

			UINavigationBar.Appearance.SetTitleTextAttributes( new UITextAttributes{
				TextColor = UIColor.Red,
			});

			// Reflection
			var tas = new testAddSeparate();
			var method = typeof(testAddSeparate).GetMethod("TestGetMethod", BindingFlags.Instance|BindingFlags.NonPublic); // This line returns null in iOS.
			if (method !=null) {
				var generic = method.MakeGenericMethod(new Type[]{typeof(string)} ); // Again this function returns null, since method was null.
				var x = generic.Invoke(tas, new object[]{"Hello World"});
				Console.WriteLine("Invoked Generic: {0}", x);
				Console.WriteLine("Method exists, was found, and Generic method was created and executed");
			}
			else 
				Console.WriteLine("GetMethod returned null");

			// Culture INfo
			Console.WriteLine("Decimal Separator: {0}", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

			UIImageView imageView = new UIImageView(UIImage.FromFile("Icon.png"));
			imageView.Center = new PointF(View.Bounds.Width/2, 22);
			//NavigationController.NavigationBar.Add(imageView);

			aboutUsTextView.Text = "All those who believe in psychokinesis raise my hand.\nThe early bird gets the worm, but the second mouse gets the cheese.\nI almost had a psychic girlfriend but she left me before we met.\nOK, so what's the speed of dark?\nHow do you tell when you're out of invisible ink?\nIf everything seems to be going well, you have obviously overlooked something.\nSupport bacteria - they're the only culture some people have.\nWhen everything is coming your way, you're in the wrong lane.\nAmbition is a poor excuse for not having enough sense to be lazy.\nHard work pays off in the future. Laziness pays off now.\nEveryone has a photographic memory. Some just don't have film.\nShin: a device for finding furniture in the dark.\nMany people quit looking for work when they find a job.\nI intend to live forever - so far, so good.\nJoin the Army, meet interesting people, kill them.\nIf Barbie is so popular, why do you have to buy her friends?\nEagles may soar, but weasels don't get sucked into jet engines.\nWhen I'm not in my right mind, my left mind gets pretty crowded.\nBoycott shampoo! Demand the REAL poo!\nWho is General Failure and why is he reading my hard disk?\nWhat happens if you get scared half to death twice?\nI used to have an open mind but my brains kept falling out.\nI couldn't repair your brakes, so I made your horn louder.\nWhy do psychics have to ask you for your name?\nIf at first you don't succeed, destroy all evidence that you tried.\nIf at first you don't succeed, then skydiving definitely isn't for you.\nA conclusion is the place where you got tired of thinking.\nExperience is something you don't get until just after you need it.\nFor every action, there is an equal and opposite criticism.\nThe colder the X-ray table, the more of your body is required to be on it.\nThe hardness of the butter is proportional to the softness of the bread.\nThe severity of the itch is proportional to the reach.\nTo steal ideas from one person is plagiarism; to steal from many is research.\nYou never really learn to swear until you learn to drive.\nThe problem with the gene pool is that there is no lifeguard.\nMonday is an awful way to spend 1/7th of your life.\nThe sooner you fall behind, the more time you'll have to catch up. \nA clear conscience is usually the sign of a bad memory.\nIf you must choose between two evils, pick the one you've never tried before.\nChange is inevitable....except from vending machines.\nA fool and his money are soon partying.\nPlan to be spontaneous tomorrow.\nIf you think nobody cares about you, try missing a couple of payments.\nDrugs may lead to nowhere, but at least it's the scenic route.\nI'd kill for a Nobel Peace Prize.\nBills travel through the mail at twice the speed of checks.\nBorrow money from pessimists-they don't expect it back.\nHalf the people you know are below average.\n99 percent of lawyers give the rest a bad name.\n42.7 percent of all statistics are made up on the spot.\nA conscience is what hurts when all your other parts feel so good.\nOn the other hand, you have different fingers.\nI was sad because I had no shoes, until I met a man who had no feet. So I said, \"Got any shoes you're not using?\"\nMy theory of evolution is that Darwin was adopted.\nSomeone sent me a postcard picture of the earth. On the back it said, \"Wish you were here.\"\nCross country skiing is great if you live in a small country.\nI spilled spot remover on my dog. Now he's gone.\nIf you're not part of the solution, you're part of the precipitate.\n\"Did you sleep well?\" \"No, I made a couple of mistakes.\"\nMy dental hygienist is cute. Every time I visit, I eat a whole package of Oreo cookies while waiting in the lobby. Sometimes she has to cancel the rest of the afternoon's appointments.\nMy socks DO match. They're the same thickness.\nOfficer, I know I was going faster than 55MPH, but I wasn't going to be on the road an hour.\nI have two very rare photographs. One is a picture of Houdini locking his keys in his car.The other is a rare photograph of Norman Rockwell beating up a child.\nI stayed up all night playing poker with tarot cards. I got a full house and four people died.\nI used to work in a fire hydrant factory. You couldn't park anywhere near the place.\nI went to the hardware store and bought some used paint. It was in the shape of a house. I also bought some batteries, but they weren't included.\nI went to the museum where they had all the heads and arms from the statues that are in all the other museums.\nIt's a small world, but I wouldn't want to have to paint it.\nRight now I'm having amnesia and deja vu at the same time.\nWhat's another word for Thesaurus?\nWhen I get real bored, I like to drive downtown and get a great parking spot, then sit in my car and count how many people ask me if I'm leaving.\nWhen I was crossing the border into Canada, they asked if I had any firearms with me. I said, \"Well, what do you need?\"\nYou can't have everything. Where would you put it?\nA lot of people are afraid of heights. Not me, I'm afraid of widths.\nIf you were going to shoot a mime, would you use a silencer?\nI planted some bird seed. A bird came up. Now I don't know what to feed it.\nI made a chocolate cake with white chocolate. Then I took it to a potluck. I stood in line for some cake. They said, \"Do you want white cake or chocolate cake?\" I said, \"yes\".\nMy aunt gave me a walkie-talkie for my birthday. She says if I'm good, she'll give me the other one next year.\nI went to the bank and asked to borrow a cup of money. They said, \"What for?\" I said, \"I'm going to buy some sugar.\"\nI eat swiss cheese from the inside out.\nI had amnesia once or twice.\nI bought a million lottery tickets. I won a dollar.\nI got a chain letter by fax. It's very simple. You just fax a dollar bill to everybody on the list.\nI plugged my phone in where the blender used to be. I called someone. They went \"Aaaaahhhh...\"\nMy friend Sam has one leg. I went to his house. I couldn't go up the stairs.\nThe sun never sets on the British Empire. But it rises every morning. The sky must get awfully crowded.\nI brought a mirror to Lovers' Lane. I told everybody I'm Narcissus.\nYou know how it is when you decide to lie and say the check is in the mail, and then you remember it really is? I'm like that all the time.\nHow many people does it take to change a searchlight bulb?\nI was in the grocery store. I saw a sign that said \"pet supplies\". So I did. Then I went outside and saw a sign that said \"compact cars\".\nThe sky already fell. Now what?\nI wear my heart on my sleeve. I wear my liver on my pant leg.\nI still have my Christmas Tree. I looked at it today. Sure enough, I couldn't see any forests.\nWhen I was in boy scouts, I slipped on the ice and hurt my ankle. A little old lady had to help me across the street.\nIf you write the word \"monkey\" a million times, do you start to think you're Shakespeare?\nYou know how it is when you're reading a book and falling asleep, you're reading, reading...and all of a sudden you notice your eyes are closed? I'm like that all the time.\nMy roommate got a pet elephant. Then it got lost. It's in the apartment somewhere.\nSmoking cures weight problems...eventually...\nI had fried octopus last night. You have to be really quiet when you eat it. Otherwise, it emits a cloud of black smoke and falls on the floor.\nYesterday I told a chicken to cross the road. It said, \"what for?\"\nI xeroxed my watch. Now I have time to spare.\nI took a course in speed waiting. Now I can wait an hour in only ten minutes.\nI eat swiss cheese. But I only nibble on it. I make the holes bigger.\nI moved into an all-electric house. I forgot and left the porch light on all day. When I got home the front door wouldn't open.\nYou know how it is when you go to be the subject of a psychology experiment, and nobody else shows up, and you think maybe that's part of the experiment? I'm like that all the time.\nI went over to the neighbor's and asked to borrow a cup of salt. \"What are you making?\" \"A salt lick.\"\nThere aren't enough days in the weekend.\nMy friend Sally is a nudist. I went to her house. The closets have no doors. The walls are covered with see-through wallpaper. Sally plays strip poker. Whenever she loses, she has to put something on.\nThe sky is falling...no, I'm tipping over backwards.\nDroughts are because god didn't pay his water bill.\nIs \"tired old cliche\" one?\nIf you had a million Shakespeares, could they write like a monkey?\nIf you tell a joke in the forest, but nobody laughs, was it a joke?\nIt only rains straight down. God doesn't do windows.\nWhen I get bored I go to a Seven-Eleven and ask for a two-by-four and a box of three-by-fives.\nThe sign said \"eight items or less\". So I changed my name to Les.\nYesterday I saw a chicken crossing the road. I asked it why. It told me it was none of my business.\nI rented a lottery ticket. I won a million dollars. But I had to give it back.\nIn school, every period ends with a bell. Every sentence ends with a period. Every crime ends with a sentence.\nI xeroxed a mirror. Now I have an extra xerox machine.\nI took a course in speed reading. Then I got Reader's Digest on microfilm. By the time I got the machine set up, I was done.\nYesterday I found out what doughnuts are for. You put them on doughbolts. They hold dough airplanes together. For kids, they make erector sets out of play-dough.\nI went to a haunted house, looked under the kitchen table, and found spirit gum.\nI went to a garage sale. \"How much for the garage?\" \"It's not for sale.\"\nI went to San Francisco. I found someone's heart.\nI know the guy who writes all those bumper stickers. He hates New York.\nA beautiful woman moved in next door. So I went over and returned a cup of sugar. \"You didn't borrow this.\" \"I will.\"\nI had my coathangers spayed.\nI washed a sock. Then I put it in the dryer. When I took it out, it was gone.\nThe Bermuda Triangle got tired of warm weather. It moved to Alaska. Now Santa Claus is missing.\nI went to a fancy french restaurant called \"Deja Vu.\" The headwaiter said, \"Don't I know you?\"\nLast week I forgot how to ride a bicycle.\nI took lessons in bicycle riding. But I could only afford half of them. Now I can ride a unicycle.\nI had some eyeglasses. I was walking down the street when suddenly the prescription ran out.\nI got food poisoning today. I don't know when I'll use it.\nI put my air conditioner in backwards. It got cold outside. The weatherman on TV was confused. \"It was supposed to be hot today.\"\nI was in a job interview and I opened a book and started reading. Then I said to the guy, \"Let me ask you a question. If you are in a spaceship that is traveling at the speed of light, and you turn on the headlights, does anything happen?\" He said, \"I don't know.\" I said, \"I don't want your job.\"\nI was in the first submarine. Instead of a periscope, they had a kaleidoscope. \"We're surrounded.\"\nI went camping and borrowed a circus tent by mistake. I didn't notice until I got it set up. People complained because they couldn't see the lake.\nWhen I turned two I was really anxious, because I'd doubled my age in a year. I thought, if this keeps up, by the time I'm six I'll be ninety.\nSponges grow in the ocean. That just kills me. I wonder how much deeper the ocean would be if that didn't happen.\nI put instant coffee in a microwave oven and almost went back in time.\nIt's a fine night to have an evening.\nEven snakes are afraid of snakes.\nI can't stop thinking like this.\nYou know how it is when you're walking up the stairs, and you get to the top, and you think there's one more step? I'm like that all the time.\nI put hardwood floors on top of wall-to-wall carpet.\nTinsel is really snakes' mirrors.\nTwo babies were born on the same day at the same hospital. They lay there and looked at each other. Their families came and took them away. Eighty years later, by a bizarre coincidence, they lay in the same hospital, on their deathbeds, next to each other. One of them looked at the other and said, \"So. What did you think?\"\nMy grandfather gave me a watch. It doesn't have any hands or numbers. He says it's very accurate. I asked him what time it was. You can guess what he told me.\nI spent all my money on a FAX machine. Now I can only FAX collect.\nWhat are imitation rhinestones?\nIf a word in the dictionary were misspelled, how would we know?\nIf God dropped acid, would he see people?\nIn my house there's this light switch that doesn't do anything. Every so often I would flick it on and off just to check. Yesterday, I got a call from a woman in Madagascar. She said, \"Cut it out.\"\nIt's a good thing we have gravity or else when birds died they'd just stay right up there. Hunters would be all confused.\nI wrote a few children's books...not on purpose.\nI wrote a song, but I can't read music so I don't know what it is. Every once\nin a while I'll be listening to the radio and I say, \"I think I might have written that.\"\n\"So, do you live around here often?\"\nI got up one morning, couldn't find my socks, so I called Information. She said, \"Hello, Information.\" I said, \"I can't find my socks.\" She said, \"They're behind the couch.\" And they were!\nWhen I was a little kid we had a sand box. It was a quicksand box. I was an only child....eventually.\nA friend of mine once sent me a post card with a picture of the entire planet Earth taken from space. On the back it said, \"Wish you were here.\"\nI'm moving to Mars next week, so if you have any boxes...\nI saw a bank that said \"24 Hour Banking\", but I don't have that much time.\nI went to the museum where they had all the heads and arms from the statues that are in all the other museums.\nI like to go to art museums and name the untitled paintings... Boy With Pail... Kitten On Fire.\nI went to a restaurant that serves \"breakfast at any time\". So I ordered French Toast during the Renaissance.\nI went to this restaurant last night that was set up like a big buffet in the shape of an Ouija board. You'd think about what kind of food you want, and the table would move across the floor to it.\nI went to a general store. They wouldn't let me buy anything specifically.\nI worked in a health food store once. A guy came in and asked me, \"If I melt dry ice, can I take a bath without getting wet?\"\nI went down the street to the 24-hour grocery. When I got there, the guy was locking the front door. I said, \"Hey, the sign says you're open 24 hours.\" He said, \"Yes, but not in a row.\"\nI love to go shopping. I love to freak out salespeople. They ask me if they can help me, and I say, \"Have you got anything I'd like?\" Then they ask me what size I need, and I say, \"Extra medium.\"\nI saw a small bottle of cologne and asked if it was for sale. She said, \"It's free with purchase.\" I asked her if anyone bought anything today.\nI met this wonderful girl at Macy's. She was buying clothes and I was putting Slinkies on the escalator.\nThere was a power outage at a department store yesterday. Twenty people were trapped on the escalators.\nI bought my brother some gift-wrap for Christmas. I took it to the Gift Wrap department and told them to wrap it, but in a different print so he would know when to stop unwrapping.\nFor my birthday I got a humidifier and a de-humidifier...I put them in the same room and let them fight it out.\nEver notice how irons have a setting for *permanent* press? I don't get it...\nI couldn't find the remote control to the remote control.\nI invented the cordless extension cord.\nI saw a close friend of mine the other day... He said, \"Stephen, why haven't you called me?\" I said, \"I can't call everyone I want. My new phone has no five on it.\" He said, \"How long have you had it?\" I said, \"I don't know... my calendar has no sevens on it.\"\nToday I dialed a wrong number... The other person said, \"Hello?\" and I said, \"Hello, could I speak to Joey?\"... They said, \"Uh... I don't think so... he's only 2 months old.\" I said, \"I'll wait.\"\nI don't like the sound of my phone ringing so I put my phone inside my fish tank. I can't hear it, but every time I get a call I see the fish go like this <<<>>><<>><<<<. I go down to the pet store -- \"Gimme another ten guppies, I got a lotta calls yesterday.\"\nI installed a skylight in my apartment...The people who live above me are furious!\nAll of the people in my building are insane. The guy above me designs synthetic hairballs for ceramic cats. The lady across the hall tried to rob a department store...with a pricing gun. She said, \"Give me all of the money in the vault, or I'm marking down everything in the store.\"\nDoing a little work around the house. I put fake brick wallpaper over a real brick wall, just so I'd be the only one who knew. People come over and I'm gonna say, \"Go ahead, touch it...it feels real.\"\nIn my house on the ceilings I have paintings of the rooms above...so I never have to go upstairs.\nOne time the power went out in my house and I had to use the flash on my camera to see my way around. I made a sandwich and took fifty pictures of my face./The neighbors thought there was lightning in my house.\nAll the plants in my house are dead---I shot them last night. I was teasing them by watering them with ice cubes.\nI have a microwave fireplace in my house...The other night I laid down in front of the fire for the evening in two minutes.\nWinny and I lived in a house that ran on static electricity...If you wanted to run the blender, you had to rub balloons on your head. If you wanted to cook, you had to pull off a sweater real quick.\nI bought a house, on a one-way dead-end road. I don't know how I got there.\nI went to the hardware store and bought some used paint. It was in the shape of a house. I also bought some batteries, but they weren't included. So I had to buy them again.\nMy house is made out of balsa wood, so when I want to scare the neighborhood kids I lift it over my head and tell them to get out of my yard or I'll throw it at them.\nThe other night I came home late, and tried to unlock my house with my car keys. I started the house up. So, I drove it around for a while. I was speeding, and a cop pulled me over. He asked where I lived. I said, \"right here, officer\". Later, I parked it on the freeway, got out, and yelled at all the cars, \"Get out of my driveway!\"\nMy house is on the median strip of a highway. You don't really notice, except I have to leave the driveway doing 60 MPH.\nFor a while I didn't have a car...I had a helicopter...no place to park it, so I just tied it to a lamp post and left it running.\nI hooked up my accelerator pedal in my car to my brake lights. I hit the gas, people behind me stop, and I'm gone.\nI replaced the headlights in my car with strobe lights, so it looks like I'm the only one moving.\nI play the harmonica. The only way I can play is if I get my car going really fast, and stick it out the window. I put a new engine in my car, but forgot to take the old one out. Now my car goes 500 miles per hour. The harmonica sounds *amazing*.\nI watched the Indy 500, and I was thinking that if they left earlier they wouldn't have to go so fast.\nI had to stop driving my car for a while...the tires got dizzy.\nMy neighbor has a circular driveway...he can't get out.\nI have an answering machine in my car. It says, \"I'm home now. But leave a message and I'll call when I'm out.\"\nLast year we drove across the country. We switched on the driving...every half mile...We had one cassette tape to listen to on the entire trip...I don't remember what it was.\nI saw a sign: \"Rest Area 25 Miles\". That's pretty big. Some people must be really tired.\nA cop stopped me for speeding. He said, \"Why were you going so fast?\" I said, \"See this thing my foot is on? It's called an accelerator. When you push down on it, it sends more gas to the engine. The whole car just takes right off. And see this thing? This steers it.\"\nOne time a cop pulled me over for running a stop sign. He said, \"Didn't you see the stop sign?\" I said, \"Yeah, but I don't believe everything I read.\"\nI got my driver's license photo taken out of focus on purpose. Now when I get pulled over the cop looks at it (moving it nearer and farther, trying to see it clearly)...and says, \"Here, you can go.\"\nThe judge asked, \"What do you plead?\" I said, \"Insanity, your honour, who in their right mind would park in the passing lane?\"\nI can remember the first time I had to go to sleep. Mom said, \"Steven, time to go to sleep.\" I said, \"But I don't know how.\" She said, \"It's real easy. Just go down to the end of tired and hang a left.\" So I went down to the end of tired, and just out of curiosity I hung a right. My mother was there, and she said \"I thought I told you to go to sleep.\"\nI hate it when my foot falls asleep during the day because that means it's going to be up all night.\nWhen I woke up this morning my girlfriend asked me, \"Did you sleep good?\" I said, \"No, I made a few mistakes.\"\nI was trying to daydream, but my mind kept wandering.\nOne night I walked home very late and fell asleep in somebody's satellite dish. My dreams were showing up on TV's all over the world.\nMy girlfriend does her nails with white-out. When she's asleep, I go over there and write misspelled words on them.\nI bought a self learning record to learn Spanish. I turned it on and went to sleep; the record got stuck. The next day I could only stutter in Spanish.\nI was going to tape some records onto a cassette, but I got the wires backwards. I erased all of the records. When I returned them to my friend, he said, \"Hey, these records are all blank.\"\nLast year I went fishing with Salvador Dali. He was using a dotted line. He caught every other fish.\nThere's a fine line between fishing and standing on the shore looking like an idiot.\nI bought a dog the other day...I named him Stay. It's fun to call him... \"Come here, Stay! Come here, Stay!\" He went insane. Now he just ignores me and keeps typing.\nI put contact lenses in my dog's eyes. They had little pictures of cats on them. Then I took one out and he ran around in circles.\nThe other day, I was walking my dog around my building...on the ledge. Some people are afraid of heights. Not me, I'm afraid of widths.\nThey say we're 98% water. We're that close to drowning...[picks up his glass of water from the stool]...I like to live on the edge...\nI bought some powdered water, but I don't know what to add to it.\nI was born by Caesarian section...but not so you'd notice. It's just that when I leave a house, I go out through the window.\nWhen I was little, my grandfather used to make me stand in a closet for five minutes without moving. He said it was elevator practice.\nI didn't get a toy train like the other kids. I got a toy subway instead. You couldn't see anything, but every now and then you'd hear this rumbling noise go by.\nIt is the journey that is to be exalted, not the prize at its end. - Anonymous\nPhilosophy is questions that may never be answered, religion is answers that may never be questioned. - Anonymous\nSocialism is the radical idea that humans should care for one another. - Jon Goldberger\nAnyone who quotes themself is an asshole. - Jon Goldberger\nThere is no time like the present to procrastinate. - Anonymous\nPeople who think they know everything are a great annoyance to those of us who do. - Isaac Asimov \nA word to the wise ain't necessary - it's the stupid ones that need the advice. - Bill Cosby\nA child of five would understand this. Send someone to fetch a child of five. - Groucho Marx\nA lot of people are afraid of heights. Not me, I'm afraid of widths. - Steven Wright\nBehind every great man is a woman rolling her eyes. - Jim Carrey\nGet your facts first, then you can distort them as you please. - Mark Twain\nI like long walks, especially when they are taken by people who annoy me. - Fred Allen\nA nickel ain't worth a dime anymore. -  Yogi Berra\nAlways remember that you are absolutely unique. Just like everyone else. - Margaret Mead\nDo not worry about avoiding temptation. As you grow older it will avoid you. - Joey Adams\nI always wanted to be somebody, but now I realize I should have been more specific. - Lily Tomlin\nIt takes considerable knowledge just to realize the extent of your own ignorance. - Thomas Sowell\nI refuse to join any club that would have me as a member. - Groucho Marx\nBy all means let's be open-minded, but not so open-minded that our brains drop out. - Richard Dawkins\nHappiness is having a large, loving, caring, close-knit family in another city. - George Burns\nWe must believe in luck. For how else can we explain the success of those we don’t like? - Jean Cocteau\nPeople who have what they want are very fond of telling people who don't have what they want that they don’t want it. - Ogden Nash\nEverybody lies, but it doesn’t matter since nobody listens. - Nick Diamos\nTo be sure of hitting the target, shoot first. And, whatever you hit, call it the target. - Ashleigh Brilliant\nThey’ve finally come up with the perfect office computer. If it makes a mistake, it blames another computer. - Milton Berle\nAvoid fruits and nuts. You are what you eat. - Jim Davis\nGraduation Speech: I’d like to thank the internet, Google, Wikipedia, Microsoft Word, and Copy & Paste. - Unknown\nIt matters not whether you win or lose; what matters is whether I win or lose. - Darrin Weinberg\nA good lawyer knows the law; a clever one takes the judge to lunch. - Unknown\nAlways end the name of your child with a vowel, so that when you yell the name will carry. - Bill Cosby\nIf things get any worse, I’ll have to ask you to stop helping me. - Anonymous\nThe duty of a patriot is to protect his country from its government. - Thomas Paine\nA house is just a place to keep your stuff while you go out and get more stuff. - George Carlin\nIf you can make a girl laugh – you can make her do anything. - Marilyn Monroe\nThe towels were so thick there I could hardly close my suitcase. - Yogi Berra\nIt takes 8,460 bolts to assemble an automobile, and one nut to scatter it all over the road. - Unknown\nIf it weren’t for electricity we’d all be watching television by candlelight. - George Gobal\nTV has proved that people will look at anything rather than each other. - Ann Landers\nAlways do sober what you said you’d do drunk. That will teach you to keep your mouth shut. - Ernest Hemingway\nBe nice to nerds. Chances are you’ll end up working with one. - Bill Gates\nWhen a subject becomes totally obsolete we make it a required course. - Peter Drucker\nDid you ever walk in a room and forget why you walked in? I think that’s how dogs spend their lives. - Sue Murphy\nIf you ask me anything I don’t know, I’m not going to answer. - Yogi Berra\nIf it’s sent by ship then it’s a cargo, if it’s sent by road then it’s a shipment. - Dave Allen\nThe quickest way to double your money is to fold it in half and put it back in your pocket. - Will Rogers\nWhat do you mean, my birth certificate expired? - Anonymous\nDon’t let your mind wander, Its too little to be let out alone. - Anonymous\nNobody goes where the crowds are anymore. It’s too crowded. - Yogi Berra\nThe only thing that interferes with my learning is my education. - Albert Einstein\nAs far as the laws of mathematics refer to reality, they are not certain; as far as they are certain, they do not refer to reality. - Albert Einstein\nCommon sense is the collection of prejudices acquired by age eighteen. - Albert Einstein\nThe release of atomic energy has not created a new problem. It has merely made more urgent the necessity of solving an existing one. - Albert Einstein\nIf you are out to describe the truth, leave elegance to the tailor. - Albert Einstein\nI know not with what weapons World War III will be fought, but World War IV will be fought with sticks and stones. - Albert Einstein\nIn the beginning was nonsense, and the nonsense was with God, and the nonsense was God. - Anonymous\nA casual stroll through a lunatic asylum shows that faith does not prove anything. - Friedrich Neitzsche\nAh, women. They make the highs higher and the lows more frequent. - Friedrich Neitzsche\nIs man one of God’s blunders? Or is God one of man’s blunders? - Friedrich Neitzsche\nMany are stubborn in pursuit of the path they have chosen, few in pursuit of the goal. - Friedrich Neitzsche\nBe careful about reading health books. You may die of a misprint. - Mark Twain\nI have never let my schooling interfere with my education. - Mark Twain\nThe man who doesn’t read good books has no advantage over the man who can’t read them. - Mark Twain\nWhy do you sit there looking like an envelope without any address on it? - Mark Twain\nPrejudices are what fools use for reason. - Voltaire\nIf there were no God, it would have been necessary to invent him. - Voltaire\nEvery man is guilty of all the good he didn’t do. - Voltaire\nNo snowflake in an avalanche ever feels responsible. - Voltaire\nThe true triumph of reason is that it enables us to get along with those who do not possess it. - Voltaire\nIt is hard to free fools from the chains they revere. - Voltaire\nThere are men who can think no deeper than a fact. - Voltaire\nAnyone who has the power to make you believe absurdities has the power to make you commit injustices. - Voltaire\nAnything too stupid to be said is sung. - Voltaire\nGovernments need to have both shepherds and butchers. - Voltaire\nOne of the penalties for refusing to participate in politics is that you end up being governed by your inferiors. - Plato\nNo one ever teaches well who wants to teach, or governs well who wants to govern. - Plato\nCourage is knowing what not to fear. - Plato\nThe measure of a man is what he does with power. - Plato\nA lie gets halfway around the world before the truth has a chance to get its pants on. - Winston Churchill\nIf you are going through hell, keep going. - Winston Churchill\nThe best argument against democracy is a five-minute conversation with the average voter. - Winston Churchill\nIt has been said that democracy is the worst form of government except all the others that have been tried. - Winston Churchill\nThink of how stupid the average person is, and realize half of them are stupider than that. - George Carlin\nYou know the good part about all those executions in Texas? Fewer Texans. - George Carlin\nI never fucked a ten, but one night, I fucked five twos. - George Carlin\nWhat year did Jesus think it was? - George Carlin\nAtheism is a non-prophet organization. - George Carlin\n“No comment” is a comment. - George Carlin\nIf a man smiles all the time, he’s probably selling something that doesn’t work. - George Carlin\nThe reason they call it the American Dream is because you have to be asleep to believe it. - George Carlin\nBoy, those French: They have a different word for everything! - Steve Martin\nThere is one thing I would break up over, and that is if she caught me with another woman. I won’t stand for that. - Steve Martin\nI believe that sex is one of the most beautiful, natural, wholesome things that money can buy. -  Tom Clancy\nFirst the doctor told me the good news: I was going to have a disease named after me. - Steve Martin\nI celebrated Thanksgiving in an old-fashioned way. I invited everyone in my neighborhood to my house, we had an enormous feast, and then I killed them and took their land. - Jon Stewart\nHere’s something to think about: How come you never see a headline like ‘Psychic Wins Lottery’? - Jay Leno\nThe Supreme Court has ruled that they cannot have a nativity scene in Washington, D.C. This wasn’t for any religious reasons. They couldn’t find three wise men and a virgin. - Jay Leno\nThe New England Journal of Medicine reports that 9 out of 10 doctors agree that 1 out of 10 doctors is an idiot. - Jay Leno\nI was raped by a doctor. Which is, you know, so bittersweet for a Jewish girl. - Sarah Silverman\nWhile drinking, as you pass the half way point the glass is half empty. While filling past the halfway point, the glass is half full. - Jon Goldberger\nA day without sunshine is like, you know, night. - Steve Martin \nIt is an interesting and demonstrable fact, that all children are atheists and were religion not inculcated into their minds, they would remain so. - Ernestine Rose\nI contend that we are both atheists. I just believe in one fewer god than you do. When you understand why you dismiss all the other possible gods, you will understand why I dismiss yours. - Stephen Roberts\nA thorough reading and understanding of the Bible is the surest path to atheism. - Donald Morgan\nI believe in God, only I spell it Nature. - Frank Lloyd Wright\nThere can be but little liberty on earth while men worship a tyrant in heaven. - Robert Green Ingersoll\nIf there is a God, atheism must strike Him as less of an insult than religion. - Edmond and Jules De Goncourt\nIf atheism is a religion, then bald is a hair color. - Mark Schnitzius\nThere are no atheists in foxholes\" isn't an argument against atheism, it's an argument against foxholes. - James Morrow\nNo philosophy, no religion, has ever brought so glad a message to the world as this good news of Atheism. - Annie Besant\nNothing can be more contrary to religion and the clergy than reason and common sense. - Voltaire\nIn no instance have . . . the churches been guardians of the liberties of the people. - James Madison\nHistory, I believe, furnishes no example of a priest-ridden people maintaining a free civil government. - Thomas Jefferson\nReligion is an insult to human dignity. With or without it, you'd have good people doing good things and evil people doing bad things, but for good people to do bad things, it takes religion. - Steven Weinberg\nAt present there is not a single credible established religion in the world. - George Bernard Shaw\nIt's easy to tell who the folks are that don't believe in evolution. They're the ones who have refused to participate in it. - Daniel Solove\nIt is a curious thing that God learned Greek when he wished to turn author - and that he did not learn it better. - Friedrich Nietzsche";
			//aboutUsTextView.SizeToFit();
			aboutUsTextView.UserInteractionEnabled = true;
			aboutUsTextView.Editable = false;
			aboutUsTextView.ScrollEnabled = true;
			//aboutUsTextView.RemoveFromSuperview();
			//UIColor Orange = new UIColor(0.97f, 0.56f, 0.12f, 0.88f);
			//aboutUsTextView.TintColor = Orange; //new UIColor(247F, 143F, 30F, 225F);
			aboutUsTextView.DataDetectorTypes = UIDataDetectorType.Link | UIDataDetectorType.PhoneNumber;
			Console.WriteLine("DataDetector {0}, {1}", new UIColor(0.97f, 0.56f, 0.12f, 0.88f), new UIColor(247F, 143F, 30F, 225F));


			textField.Text = "Hello";
			textField.Delegate = new TFDelegate();
			//textField.UserInteractionEnabled = false;

			btn.SetTitle("www.google.com", UIControlState.Normal);
			InvokeOnMainThread(() => {
				btn.SetTitle("www.johnnygold.com", UIControlState.Normal);
			});

			var webView = new UIWebView(this.View.Bounds); //("http://www.johnnygold.com", new RectangleF(0, 300, 200, 100));
			//			this.View.Add(webView);
			webView.ScalesPageToFit = true;
			var vc = new UIViewController();
			vc.View = webView;

			// Hide line on top of toolbar, results in transparent toolbar
			this.NavigationController.ToolbarHidden = false;
			this.NavigationController.Toolbar.SetShadowImage(new UIImage(), UIToolbarPosition.Any);
			this.NavigationController.Toolbar.SetBackgroundImage(new UIImage(), UIToolbarPosition.Any,UIBarMetrics.Default);
			UIBarButtonItem bbi = new UIBarButtonItem(UIBarButtonSystemItem.Refresh, (s,e) => {
				Console.WriteLine("Refresh clicked");});
			this.SetToolbarItems(
				new UIBarButtonItem[]{bbi},	true
			);

			btn.SetImage(UIImage.FromFile("Icon.png"), UIControlState.Normal);

			btn.TouchUpInside += (object sender, EventArgs e) => {
				//btn.TintColor = UIColor.Green;
				Console.WriteLine("Button Pressed");
				//this.PresentViewController(vc, true, null);
				this.NavigationController.PushViewController(vc, true);
				webView.LoadRequest(new NSUrlRequest( new NSUrl("http://" + btn.TitleLabel.Text)));

//				UIButton bkBtn = new UIButton(new RectangleF(100.0f, 100.0f, 100.0f, 30.0f));
//				bkBtn.TitleLabel.Text = "back to Home";
//				webView.Add(bkBtn);
//				bkBtn.TouchUpInside += (object sender2, EventArgs e2) => {
//					this.DismissViewController(true, null);
//				};
//				App.Current.EventStore.RequestAccess (EKEntityType.Event, 
//					(bool granted, NSError error2) => {
//					if (granted) {
//						//do something here
//						// create a new EKEventEditViewController. This controller is built in an allows
//						// the user to create a new, or edit an existing event.
//						MonoTouch.EventKitUI.EKEventEditViewController eventController = 
//							new MonoTouch.EventKitUI.EKEventEditViewController ();
//
//						// set the controller's event store - it needs to know where/how to save the event
//						InvokeOnMainThread(delegate{
//							eventController.EventStore = App.Current.EventStore;
//							// wire up a delegate to handle events from the controller
//							eventControllerDelegate = new CreateEventEditViewDelegate ( eventController );
//							eventController.EditViewDelegate = eventControllerDelegate;
//
//							// show the event controller
//							PresentViewController ( eventController, true, null );

//							EKEvent newEvent = EKEvent.FromStore ( App.Current.EventStore );
//							newEvent.StartDate = DateTime.Now.AddMinutes(10);
//							newEvent.EndDate = DateTime.Now.AddMinutes(20);
//							newEvent.Title = "Sample Title";
//							newEvent.Notes = "Sample note.";
//							newEvent.Calendar = App.Current.EventStore.DefaultCalendarForNewEvents;
//							newEvent.Availability = EKEventAvailability.Free;
//
//							EKAlarm[] alarmsArray = new EKAlarm[1];
//							alarmsArray[0] = EKAlarm.FromDate(newEvent.StartDate.AddSeconds(-600));
//							newEvent.Alarms = alarmsArray;
////							newEvent.AddAlarm(EKAlarm.FromDate(newEvent.StartDate.AddSeconds(-300)));
//
//							NSError error;
//
//							App.Current.EventStore.SaveEvent ( newEvent, EKSpan.ThisEvent, out error );
//
//						
//						});
//					}
//					else
//						new UIAlertView ( "Access Denied", 
//							"User Denied Access to Calendar Data", null,
//							"ok", null).Show ();
//				} );
			};

			// Xamarin.Auth
//			var auth = new OAuth2Authenticator (
//				clientId: "721794411222325",
//				scope: "",
//				authorizeUrl: new Uri ("https://m.facebook.com/dialog/oauth/"),
//				redirectUrl: new Uri ("http://www.facebook.com/connect/login_success.html"));
//
//
//			auth.Completed += (sender, eventArgs) => {
//				// We presented the UI, so it's up to us to dimiss it on iOS.
//				DismissViewController (true, null);
//
//				if (eventArgs.IsAuthenticated) {
//					// Use eventArgs.Account to do wonderful things
//				} else {
//					// The user cancelled
//				}
//			};
//			PresentViewController (auth.GetUI (), true, null);

//			ZoomingUIImageView zoomView = new ZoomingUIImageView(UIImage.FromBundle("ImageSetName"));
//			zoomView.Image = UIImage.FromBundle("ImageSetName");
//			UIButton backButton = new UIButton(new RectangleF(100.0f, 100.0f, 100.0f, 50.0f));
//			backButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
//			backButton.SetTitle("Back", UIControlState.Normal);
//			backButton.BackgroundColor = UIColor.White;
//
//			UIScrollView sv = new UIScrollView(this.View.Bounds);
//			sv.Add(zoomView);
//			sv.Add(backButton);
//
//			UIViewController svController = new UIViewController();
//			svController.View = sv;
//
//			backButton.TouchUpInside += (object sender, EventArgs e) => {
//				Console.WriteLine("Is this hit?");
//				DismissViewController(true, null);
//			};
//
//
//
//			SizeF svSize = zoomView.Bounds.Size;
//			sv.ContentSize = svSize;
//
//			sv.MaximumZoomScale = 5.0f;
//			sv.MinimumZoomScale = 0.25f;
//			sv.ViewForZoomingInScrollView  += (UIScrollView scrollView) => {return zoomView;};
//
//			this.PresentViewController(svController, true, null);
//			//this.NavigationController.PushViewController(svController, true);
//
//			sv.ZoomingEnded += (object sender, ZoomingEndedEventArgs e) => {
//				Console.WriteLine ("adsf");
//				UIScrollView zoomingView = (UIScrollView)sender;
//				bool scrollingEnabled = e.AtScale != zoomingView.MinimumZoomScale;
//				zoomingView.ScrollEnabled = scrollingEnabled;
//				sv.ScrollEnabled = !scrollingEnabled;
//
//			};

//			var picker = new MediaPicker();
//			Console.WriteLine("------" + Environment.SpecialFolder.Personal.ToString());
//			MediaPickerController controller = picker.GetTakePhotoUI(new StoreCameraMediaOptions {
//				Name = "test.jpg",
//				Directory = "MediaPickerSample"
//			});
//			controller.VideoQuality = UIImagePickerControllerQualityType.High;
//			btn.TouchUpInside += (object sender, EventArgs e) => {
//				var tas = new testAddSeparate();
//				this.NavigationController.PresentViewController(tas, true, new NSAction(delegate() {
//					Console.WriteLine("Presentation Complete IsLoaded?: {0}, {1}", tas.IsViewLoaded, tas.View.Window);
//				}));
//				this.NavigationController.PresentViewController(tas, false, null);
//				Console.WriteLine("Is Being Presented? {0}", tas.IsBeingPresented.ToString());
//				PresentViewController(controller, true, null);
//
//				controller.GetResultAsync().ContinueWith (t => {
//					// Dismiss the UI yourself
//					controller.DismissViewController(true, () => {
//						MediaFile file = t.Result;
//						this.View.Add(new UIImageView(new UIImage(t.Result.Path)));
//					});
//				}, TaskScheduler.FromCurrentSynchronizationContext());
//			};



			//AdSize
//			GADAdSize size1 = GADAdSizeCons.GADAdSizeFromSizeF(new SizeF(120, 20));
//			GADAdSize size2 = GADAdSizeCons.GADAdSizeFromSizeF(new SizeF(250, 250));
//			GADAdSize size3 = GADAdSizeCons.GADAdSizeFromSizeF(new SizeF(320, 50));
//			NSMutableArray validSizes = new NSMutableArray();
//			validSizes.Add(NSValue.FromSizeF(size1.size));
//			validSizes.Add(NSValue.FromSizeF(size2.size));
//			validSizes.Add(NSValue.FromSizeF(size3.size));
//
//			DFPBannerView bannerView = new DFPBannerView();
//
//			bannerView.ValidAdSizes = validSizes;
//
//			this.View.AddSubview(bannerView);


//			GADAdSize size1 = GADAdSizeFromCGSize(CGSizeMake(120, 20));
//			GADAdSize size2 = GADAdSizeFromCGSize(CGSizeMake(250, 250));
//			GADAdSize size3 = GADAdSizeFromCGSize(CGSizeMake(320, 50));
//			NSMutableArray *validSizes = [NSMutableArray array];
//			[validSizes addObject:[NSValue valueWithBytes:&size1 objCType:@encode(GADAdSize)]];
//			[validSizes	addObject:[NSValue valueWithBytes:&size2 objCType:@encode(GADAdSize)]];
//			[validSizes addObject:[NSValue valueWithBytes:&size3 objCType:@encode(GADAdSize)]];
//			bannerView_.validAdSizes = validSizes;




//			var tView = new UITextView(new RectangleF(0, 250, 340, 200));
//			this.View.Add(tView);
//
//			var firstAttributes = new UIStringAttributes {
//				ForegroundColor = UIColor.Red,
//				Font = UIFont.SystemFontOfSize(16f),
//				ParagraphStyle = new NSMutableParagraphStyle () {
//					MaximumLineHeight = 0.000001f, LineSpacing =-12.0f}
//			};
//
//			var journalString = new NSMutableAttributedString();
//			journalString.Append(new NSAttributedString(@"Hello world! alskd wh  hakdfh  aksh akshdahsdk ak ja skd akajshd kjah kauhdskjh akjshd kjh aksjdh kjhas d jhjkjhadk hkjh dkajh sjkjhd kjahsd kjh kdhkjahs dkjh akdsh kklaksj"));
//			journalString.SetAttributes(firstAttributes.Dictionary, new NSRange(0,
//				journalString.Length));
//
//			var journalEntryLayer = new CATextLayer ();
//			journalEntryLayer.AttributedString = journalString;
//
//			journalEntryLayer.Frame = new RectangleF (new PointF (0, 0), new SizeF(340,200));
//
//			journalEntryLayer.Wrapped = true;
//			tView.Layer.AddSublayer(journalEntryLayer);




//			NSLocale locale = NSLocale.CurrentLocale;
//			string currency = locale.CurrencySymbol;
//			Console.WriteLine(currency);
//
//
//			locale = NSLocale.FromLocaleIdentifier ("en_GB");
//			currency = locale.CurrencySymbol;
//			Console.WriteLine(currency);




//			btn.AutoresizingMask = (UIViewAutoresizing.FlexibleLeftMargin | UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleTopMargin);
//			UIToolbar toolBar = new UIToolbar();
//			toolBar.Frame = RectangleF.FromLTRB(0, 0, this.View.Frame.Size.Width, 44);
//			this.View.AddSubview(toolBar);
//
//			var barBtn = new UIBarButtonItem();
//			barBtn.TintColor = UIColor.White;
//			barBtn.Image = UIImage.FromBundle("Toolbar/Icon.png");
//			var barBtn2 = new UIBarButtonItem();
//			barBtn2.TintColor = UIColor.White;
//			barBtn2.Image = UIImage.FromBundle("Toolbar/Icon.png");
//
//			List<UIBarButtonItem> bbItems = new List<UIBarButtonItem>();
//			bbItems.Add(barBtn);
//			toolBar.SetItems(bbItems.ToArray(), true);
//
//			bbItems.Add(barBtn2);
//			toolBar.SetItems(bbItems.ToArray(), true);



//			Console.WriteLine("View: {0}", webView.ScrollView.ToString());
//			Console.WriteLine("View: {0}", webView.Subviews.ElementAt(0).ToString());
//			Console.WriteLine("WebBrowserView: {0}", webView.Subviews.ElementAt(0).Subviews.ElementAt(0));
//			Console.WriteLine("WebBrowserView: {0}", webView.ScrollView.Subviews.ElementAt(0));
//			webView.ScrollView.ViewForZoomingInScrollView += (UIScrollView sv) => {return webView;};
//			webView.ScrollView.MinimumZoomScale = 0.25f;
//			webView.ScrollView.MaximumZoomScale = 5f;
//			webView.ScrollView.SetZoomScale(0.25f, true);
//			webView.LoadRequest(new NSUrlRequest(new NSUrl("http://www.johnnygold.com")));



//			UIWebView wv = new UIWebView();
//			UIViewController wvc = new UIViewController();
//			wvc.View = wv;
//			wv.LoadRequest(new NSUrlRequest(new NSUrl("http://xamarin.com")));
//
//			//var browser = new MiniWebBrowser (new NSUrl ("http://xamarin.com"));
//			UITextView tv = new UITextView(new RectangleF(0, 200, 150, 50));
//			//browser.Add(tv);
//			wv.Add(tv);
//			tv.Ended += (sender, e) => {
//				UITextView tf = sender as UITextView;
//				Console.WriteLine("TextField editing ended {0}", tf.Text);
//			};
//			UISearchBar sb = new UISearchBar(new RectangleF(170, 200, 150, 25));
//			//browser.Add(sb);
//			wv.Add(sb);
//			sb.ShouldEndEditing += ((searchBar) => {
//				Console.WriteLine("SearchBar editing ended {0}", searchBar.Text);
//				return true;
//			});
//			//NavigationController.PushViewController (browser, true);
//			NavigationController.PushViewController (wvc, true);




//			if(Reachability.IsHostReachable("www.cognitopia.com"))
//			{
//				//Load server side help content
//				var url = new NSUrl("http://www.cognitopia.com/pphelp.php");
//				Console.WriteLine("Help " + url.AbsoluteString);
//				var urlRequest = new NSUrlRequest(url);
//				webView.LoadRequest(urlRequest);
//			}
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

//			if (!IsAuthenticated) {
//				var auth = new OAuth2Authenticator (
//					clientId: "320899005792-2nfnj7i5nqluqmaes52mujjkgtri8psc.apps.googleusercontent.com",
//					clientSecret: "ksxSCFJYO_HuzpXzCSA7GcvH",
//					scope: "https://www.googleapis.com/auth/drive",
//					authorizeUrl: new Uri ("https://accounts.google.com/o/oauth2/auth"),
//					redirectUrl: new Uri ("http://localhost"),
//					accessTokenUrl: new Uri("https://accounts.google.com/o/oauth2/token")
//				);
//
//				auth.Completed += (sender, eventArgs) => {
//					DismissViewController (true, null);
//					if (eventArgs.IsAuthenticated) {
//						// Use eventArgs.Account to do wonderful things
//						Console.WriteLine("Authenticated! {0}", eventArgs.Account);
//						IsAuthenticated = true;
//
//						AccountStore.Create().Save(eventArgs.Account, "Google");
//					}
//				};
//
//				PresentViewController (auth.GetUI (), true, null);
//			}
		}

		public override bool ShouldAutorotate()
		{
			return base.ShouldAutorotate();
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}

		public override void WillRotate(UIInterfaceOrientation toInterfaceOrientation, double duration)
		{
			base.WillRotate(toInterfaceOrientation, duration);
			Console.WriteLine("WillRotate ViewFrame = {0}", this.View.Frame);
		}

		public override void DidRotate(UIInterfaceOrientation fromInterfaceOrientation)
		{
			base.DidRotate(fromInterfaceOrientation);
			Console.WriteLine("DidRotate ViewFrame = {0}", this.View.Frame);
		}

		public void setThumbnailDataFromImage(UIImage image)
		{
			SizeF origImageSize = image.Size;

			// The Rectangle of the thumbnail
			RectangleF newRect = new RectangleF(0, 0, 40, 40);

			// Figure out a scaling ration to make sure we maintain the same aspect ratio
			float ratio = Math.Max(newRect.Size.Width / origImageSize.Width, newRect.Size.Height / origImageSize.Height);

			// Create a transparent bitmap context with a scaling factor equal to that of the screen
			UIGraphics.BeginImageContextWithOptions(newRect.Size, false, 0.0f);

			// Create a path that is a rounded rectangle
			UIBezierPath path = UIBezierPath.FromRoundedRect(newRect, 5.0f);
			// Make all subsequent drawing clip to this rounded rectangle
			path.AddClip();

			// Center the image in the thumbnail rectangle
			RectangleF projectRect = new RectangleF();
			projectRect.Width = ratio * origImageSize.Width;
			projectRect.Height = ratio * origImageSize.Height;
			projectRect.X = (newRect.Size.Width - projectRect.Size.Width) / 2.0f;
			projectRect.Y = (newRect.Size.Height - projectRect.Size.Height) / 2.0f;

			// Draw the image to the context
			image.Draw(projectRect);

			// Get the image from the image context, keep it as our thumbnail
			UIImage smallImage = UIGraphics.GetImageFromCurrentImageContext();


			// Get the PNG representation of the image and set it as our archivable data
			//NSData data = smallImage.AsPNG();
			//---------------Case 57438 ----------------------------------------
			CGImage cgi = smallImage.CGImage;
			int width = cgi.Width;
			int height = cgi.Height;
			CGColorSpace colorSpace = CGColorSpace.CreateDeviceRGB();
			byte[] rawData = new byte[width * height * 4];
			int bytesPerPixel = 4;
			int bytesPerRow = bytesPerPixel * width;
			int bitsPerComponent = 8;

			CGBitmapContext context = new CGBitmapContext(rawData, width, height, bitsPerComponent,bytesPerRow, colorSpace, CGImageAlphaInfo.PremultipliedLast);
			context.DrawImage(new RectangleF(0, 0, width, height), cgi);

			int byteCount = 0;
			foreach(Byte b in rawData)
			{
				Console.WriteLine("Byte {0} = {1}", ++byteCount, b); 
			}

			//--------------- End Case 57438 ----------------------------------------

			// Clean up image context resources, we're done
			UIGraphics.EndImageContext();
		}

	}

	public class CreateEventEditViewDelegate : MonoTouch.EventKitUI.EKEventEditViewDelegate
	{
		// we need to keep a reference to the controller so we can dismiss it
		protected MonoTouch.EventKitUI.EKEventEditViewController eventController;

		public CreateEventEditViewDelegate (MonoTouch.EventKitUI.EKEventEditViewController eventController)
		{
			// save our controller reference
			this.eventController = eventController;
		}

		// completed is called when a user eith
		public override void Completed (MonoTouch.EventKitUI.EKEventEditViewController controller, EKEventEditViewAction action)
		{
			eventController.DismissViewController (true, null);

			// action tells you what the user did in the dialog, so you can optionally
			// do things based on what their action was. additionally, you can get the 
			// Event from the controller.Event property, so for instance, you could 
			// modify the event and then resave if you'd like. 
			switch ( action ) {

				case EKEventEditViewAction.Canceled:
					break;
				case EKEventEditViewAction.Deleted:
					break;
				case EKEventEditViewAction.Saved:
					// if you wanted to modify the event you could do so here, and then
					// save:
					//App.Current.EventStore.SaveEvent ( controller.Event, )
					break;
			}
		}

	}

	public class TFDelegate : UITextFieldDelegate
	{
		public override bool ShouldReturn(UITextField textField)

		{
			// NOTE: Don't call the base implementation on a Model class
			// see http://docs.xamarin.com/guides/ios/application_fundamentals/delegates,_protocols,_and_events
			textField.ResignFirstResponder();
			return true;
		}

		public override bool ShouldChangeCharacters(UITextField textField, NSRange range, string replacementString)
		{

			Console.WriteLine("Text Edited, Range {0}, replacementString {1}", range, replacementString);
			Console.WriteLine("SelectedTextRange: {0}", textField.BeginningOfDocument);


			string str = textField.Text;
			if (replacementString == "4") {
				textField.Text = "Wow, you can count to 4!";
				UITextPosition start = textField.GetPosition(textField.BeginningOfDocument, 2);
				UITextPosition end = textField.GetPosition(textField.BeginningOfDocument, 3);
				UITextRange textRange = textField.GetTextRange(start, end);
				textField.SelectedTextRange = textRange;
				return false;
			}
			else
				return true;
		}
	}
}
	























