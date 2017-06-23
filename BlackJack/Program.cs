using System;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            //init
            Deck deck = new Deck();
            Dealer dealer = new Dealer();
            Console.WriteLine("\t\t\tWelcome To BlackJack Game!!!\n\n");
            Console.Write("How much money do you want to place? $");
            double money = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            Player player = new Player(money);
            string wantContinue;
            do
            {
                Console.Clear();
                deck.Shuffle();
                player.ClearHandCards();
                dealer.ClearHandCards();
                Console.WriteLine("Your current blance: ${0}", player.Blance);
                
                // if a bet is not between 2-500 or the bet is more than balance, reprompt to the player again.
                do
                {
                    if(player.Blance < 2)
                    {
                        Console.WriteLine("You don't have enough money! Minimum bet is $2\n");
                        Console.WriteLine("Thanks for playing!  Goodbye!\n");
                        return;
                    }
                    Console.Write("How much would you like to bet? ($2 - $500) $");
                    player.Bet = Convert.ToDouble(Console.ReadLine());
                    if(player.Bet < 2 || player.Bet > 500)
                    {
                        Console.WriteLine("The general limits are from $2 to $500.\n");
                    }
                    else if ((player.Bet > player.Blance) && (2<player.Bet && player.Bet<=500))
                    {
                        Console.WriteLine("You don't have enough $$ to bet. Please lower down your bet :)\n");
                    }

                } while(player.Bet <2 || player.Bet >500 || (player.Bet > player.Blance) && (2 < player.Bet && player.Bet <= 500));

                Console.WriteLine("Bet: ${0}\n", player.Bet);

                // player and dealer draw 2 cards from deck
                for (int i = 0; i < 2; i++)
                {
                    player.DrawCard(deck.DealCard());
                }
                for (int i = 0; i < 2; i++)
                {
                    dealer.DrawCard(deck.DealCard());
                }
                player.ShowCards();
                // show one card to player
                dealer.ShowOneCard();

                string hitOrStand;
                do
                {
                    Console.WriteLine("\nHit(h) or Stand(s)");
                    hitOrStand = Console.ReadLine();
                    Console.WriteLine();
                    // if player type hit, player will draw a card from the deck.
                    if (hitOrStand.ToLower() == "h")
                    {
                        player.DrawCard(deck.DealCard());
                        if (player.Score > 21)
                        {
                            PrintWhoWin("L",player,dealer);
                            break;
                        }
                        else
                        {
                            player.ShowCards();
                            dealer.ShowOneCard();
                        }
                    }
                    // if player type stand, dealer will draw cards until the point is 17 or more.
                    else if (hitOrStand.ToLower() == "s")
                    {
                        while (dealer.Score < 17)
                        {
                            dealer.DrawCard(deck.DealCard());
                        }
                        if(dealer.Score > 21)
                        {
                            PrintWhoWin("W", player,dealer);
                        }
                        else
                        {
                            // Compare with player to see who's winner
                            if(dealer.Score > player.Score)
                            {
                                PrintWhoWin("L", player,dealer);
                            }
                            else
                            {
                                if(dealer.Score == player.Score)
                                {
                                    PrintWhoWin("T", player,dealer);
                                }
                                else
                                {
                                    PrintWhoWin("W", player,dealer);
                                }
                            }
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invailed input!");
                    }

                } while (hitOrStand.ToLower() != "s");

                Console.WriteLine("Wanna Continue? (y/n)");
                wantContinue = Console.ReadLine();
                if(wantContinue.ToLower() != "n" && wantContinue.ToLower() != "y")
                {
                    Console.WriteLine("Invailed input!");
                    return;
                }
            } while (wantContinue.ToLower() != "n");

            Console.WriteLine("Thanks for playing!  Goodbye!\n");
        }

        private static void PrintWhoWin(string str, Player player, Dealer dealer)
        {
            player.ShowCards();
            dealer.ShowCards();
            if (str == "W")
            {
                Console.WriteLine("Congratulations You Won!! :D");
                player.Blance += player.Bet;
            }
            else if (str == "L")
            {
                Console.WriteLine("Sorry, You lost!! :(");
                player.Blance -= player.Bet;
            }
            else if(str == "T")
            {
                Console.WriteLine("Oops...It's a Tie :/\nNothing Changes");
            }
            Console.WriteLine("Now You have ${0} left.\n", player.Blance);
        }

    }
}
