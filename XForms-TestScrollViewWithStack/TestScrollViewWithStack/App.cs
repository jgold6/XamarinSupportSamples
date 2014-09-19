using System;
using Xamarin.Forms;

namespace TestScrollViewWithStack
{
	public class App
	{
		public static Page GetMainPage()
		{	
			ContentPage cp = new ContentPage();
			ScrollView sv = new ScrollView{
				Orientation = ScrollOrientation.Vertical,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			Button btnAdd = new Button{
				Text = "Add Control"
			};
			Button btnRemove = new Button{
				Text = "Remove Control"
			};
			Label lbl1 = new Label{
				Text = "All those who believe in psychokinesis raise my hand.\nThe early bird gets the worm, but the second mouse gets the cheese.\nI almost had a psychic girlfriend but she left me before we met.\nOK, so what's the speed of dark?\nHow do you tell when you're out of invisible ink?\nIf everything seems to be going well, you have obviously overlooked something.\nSupport bacteria - they're the only culture some people have.\nWhen everything is coming your way, you're in the wrong lane.\nAmbition is a poor excuse for not having enough sense to be lazy.\nHard work pays off in the future. Laziness pays off now.\nEveryone has a photographic memory. Some just don't have film.\nShin: a device for finding furniture in the dark.\nMany people quit looking for work when they find a job.\nI intend to live forever - so far, so good.\nJoin the Army, meet interesting people, kill them.\nIf Barbie is so popular, why do you have to buy her friends?\nEagles may soar, but weasels don't get sucked into jet engines.\nWhen I'm not in my right mind, my left mind gets pretty crowded.\nBoycott shampoo! Demand the REAL poo!\nWho is General Failure and why is he reading my hard disk?\nWhat happens if you get scared half to death twice?\nI used to have an open mind but my brains kept falling out.\nI couldn't repair your brakes, so I made your horn louder.\nWhy do psychics have to ask you for your name?\nIf at first you don't succeed, destroy all evidence that you tried.\nIf at first you don't succeed, then skydiving definitely isn't for you.\nA conclusion is the place where you got tired of thinking.\nExperience is something you don't get until just after you need it.\nFor every action, there is an equal and opposite criticism.\nThe colder the X-ray table, the more of your body is required to be on it.\nThe hardness of the butter is proportional to the softness of the bread.\nThe severity of the itch is proportional to the reach.\nTo steal ideas from one person is plagiarism; to steal from many is research.\nYou never really learn to swear until you learn to drive.\nThe problem with the gene pool is that there is no lifeguard.\nMonday is an awful way to spend 1/7th of your life.\nThe sooner you fall behind, the more time you'll have to catch up. \nA clear conscience is usually the sign of a bad memory.\nIf you must choose between two evils, pick the one you've never tried before.\nChange is inevitable....except from vending machines.\nA fool and his money are soon partying.\nPlan to be spontaneous tomorrow.\nIf you think nobody cares about you, try missing a couple of payments.\nDrugs may lead to nowhere, but at least it's the scenic route.\nI'd kill for a Nobel Peace Prize.\nBills travel through the mail at twice the speed of checks.\nBorrow money from pessimists-they don't expect it back.\nHalf the people you know are below average.\n99 percent of lawyers give the rest a bad name."
			};
			Label lbl2 = new Label{
				Text = "42.7 percent of all statistics are made up on the spot.\nA conscience is what hurts when all your other parts feel so good.\nOn the other hand, you have different fingers.\nI was sad because I had no shoes, until I met a man who had no feet. So I said, \"Got any shoes you're not using?\"\nMy theory of evolution is that Darwin was adopted.\nSomeone sent me a postcard picture of the earth. On the back it said, \"Wish you were here.\"\nCross country skiing is great if you live in a small country.\nI spilled spot remover on my dog. Now he's gone.\nIf you're not part of the solution, you're part of the precipitate.\n\"Did you sleep well?\" \"No, I made a couple of mistakes.\"\nMy dental hygienist is cute. Every time I visit, I eat a whole package of Oreo cookies while waiting in the lobby. Sometimes she has to cancel the rest of the afternoon's appointments.\nMy socks DO match. They're the same thickness.\nOfficer, I know I was going faster than 55MPH, but I wasn't going to be on the road an hour.\nI have two very rare photographs. One is a picture of Houdini locking his keys in his car.The other is a rare photograph of Norman Rockwell beating up a child.\nI stayed up all night playing poker with tarot cards. I got a full house and four people died.\nI used to work in a fire hydrant factory. You couldn't park anywhere near the place.\nI went to the hardware store and bought some used paint. It was in the shape of a house. I also bought some batteries, but they weren't included.\nI went to the museum where they had all the heads and arms from the statues that are in all the other museums.\nIt's a small world, but I wouldn't want to have to paint it.\nRight now I'm having amnesia and deja vu at the same time.\nWhat's another word for Thesaurus?\nWhen I get real bored, I like to drive downtown and get a great parking spot, then sit in my car and count how many people ask me if I'm leaving.\nWhen I was crossing the border into Canada, they asked if I had any firearms with me. I said, \"Well, what do you need?\"\nYou can't have everything. Where would you put it?\nA lot of people are afraid of heights. Not me, I'm afraid of widths.\nIf you were going to shoot a mime, would you use a silencer?\nI planted some bird seed. A bird came up. Now I don't know what to feed it.\nI made a chocolate cake with white chocolate. Then I took it to a potluck. I stood in line for some cake. They said, \"Do you want white cake or chocolate cake?\" I said, \"yes\".\nMy aunt gave me a walkie-talkie for my birthday. She says if I'm good, she'll give me the other one next year.\nI went to the bank and asked to borrow a cup of money. They said, \"What for?\" I said, \"I'm going to buy some sugar.\"\nI eat swiss cheese from the inside out.\nI had amnesia once or twice.\nI bought a million lottery tickets. I won a dollar.\nI got a chain letter by fax. It's very simple. You just fax a dollar bill to everybody on the list.\nI plugged my phone in where the blender used to be. I called someone. They went \"Aaaaahhhh...\"\nMy friend Sam has one leg. I went to his house. I couldn't go up the stairs.\nThe sun never sets on the British Empire. But it rises every morning. The sky must get awfully crowded.\nI brought a mirror to Lovers' Lane. I told everybody I'm Narcissus.\nYou know how it is when you decide to lie and say the check is in the mail, and then you remember it really is? I'm like that all the time.\nHow many people does it take to change a searchlight bulb?\nI was in the grocery store. I saw a sign that said \"pet supplies\". So I did. Then I went outside and saw a sign that said \"compact cars\".\nThe sky already fell. Now what?\nI wear my heart on my sleeve. I wear my liver on my pant leg.\nI still have my Christmas Tree. I looked at it today. Sure enough, I couldn't see any forests.\nWhen I was in boy scouts, I slipped on the ice and hurt my ankle. A little old lady had to help me across the street.\nIf you write the word \"monkey\" a million times, do you start to think you're Shakespeare?\nYou know how it is when you're reading a book and falling asleep, you're reading, reading...and all of a sudden you notice your eyes are closed? I'm like that all the time.\nMy roommate got a pet elephant. Then it got lost. It's in the apartment somewhere.\nSmoking cures weight problems...eventually...\nI had fried octopus last night. You have to be really quiet when you eat it. Otherwise, it emits a cloud of black smoke and falls on the floor.\nYesterday I told a chicken to cross the road. It said, \"what for?\"\nI xeroxed my watch. Now I have time to spare."
			};
			StackLayout sl = new StackLayout{
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					btnAdd,
					btnRemove,
					lbl1,
					lbl2
				}
			};

			btnRemove.Clicked += (object sender, EventArgs e) => {
				//lbl2.IsVisible = false; // ForceLayout not needed
				sl.Children.Remove(lbl2); // ForceLayout needed
				//sl.ForceLayout(); // Not needed
				sv.ForceLayout();
			};

			sv.Content = sl;
			cp.Content = sv;
			return new NavigationPage(cp);
		}
	}
}

