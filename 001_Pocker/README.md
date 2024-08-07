## 課題仕様書: コンソール上でのポーカーゲームアプリケーション

### 1. 概要
この課題では、Javaを使用してコンソールアプリケーションとして動作するポーカーゲームを実装します。プレイヤーはコンピュータと対戦し、手札の強さを競います。最終的なソースコードはGitHubの公開リポジトリに配置し、そのURLをメールで提出してください。

### 2. ゲームのルール
- 使用するポーカーのルールは「5カードドロー」です。
- プレイヤーとコンピュータはそれぞれ5枚のカードを持ちます。
- プレイヤーは1回だけカードを交換できます。
- 最終的な手札の強さを比較し、勝者を決定します。

### 3. 要求機能

#### 3.1 ゲーム開始
- ゲーム開始時にプレイヤーに名前を入力させます。
- トランプのデッキをシャッフルし、プレイヤーとコンピュータに5枚ずつカードを配ります。

#### 3.2 カードの表示
- プレイヤーの手札をコンソールに表示します。
- カードは「2H（2 of Hearts）」のように表示します。

#### 3.3 カード交換
- プレイヤーは1回だけ任意の枚数のカードを交換できます。
- 交換するカードの番号を入力させ、新しいカードを配ります。

#### 3.4 コンピュータの動作
- コンピュータはランダムに1～3枚のカードを交換します。

#### 3.5 勝者の決定
- 最終的な手札の強さを比較し、勝者を決定します。
- 勝者の名前と手札を表示します。

### 4. クラス設計

#### 4.1 Cardクラス
- フィールド: `suit`（スート）, `rank`（ランク）
- メソッド: コンストラクタ, `toString()`

#### 4.2 Deckクラス
- フィールド: `cards`（カードのリスト）
- メソッド: コンストラクタ, `shuffle()`, `dealCard()`

#### 4.3 Playerクラス
- フィールド: `name`（名前）, `hand`（手札）
- メソッド: コンストラクタ, `showHand()`, `exchangeCards()`

#### 4.4 PokerGameクラス
- フィールド: `player`（プレイヤー）, `computer`（コンピュータ）, `deck`（デッキ）
- メソッド: `startGame()`, `dealInitialCards()`, `playerTurn()`, `computerTurn()`, `determineWinner()`

### 5. 実装手順

#### 5.1 Cardクラスの実装
1. `Card`クラスを作成し、`suit`と`rank`フィールドを定義します。
2. コンストラクタを実装し、`suit`と`rank`を初期化します。
3. `toString()`メソッドをオーバーライドし、カードの表示形式を定義します。

```java
public class Card {
    private String suit;
    private String rank;

    public Card(String suit, String rank) {
        this.suit = suit;
        this.rank = rank;
    }

    @Override
    public String toString() {
        return rank + suit;
    }
}
```

#### 5.2 Deckクラスの実装
1. `Deck`クラスを作成し、`cards`フィールドを定義します。
2. コンストラクタで52枚のカードを生成し、`cards`リストに追加します。
3. `shuffle()`メソッドを実装し、デッキをシャッフルします。
4. `dealCard()`メソッドを実装し、デッキから1枚のカードを取り出します。

```java
import java.util.*;

public class Deck {
    private List<Card> cards;

    public Deck() {
        cards = new ArrayList<>();
        String[] suits = {"H", "D", "C", "S"};
        String[] ranks = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        for (String suit : suits) {
            for (String rank : ranks) {
                cards.add(new Card(suit, rank));
            }
        }
    }

    public void shuffle() {
        Collections.shuffle(cards);
    }

    public Card dealCard() {
        return cards.remove(cards.size() - 1);
    }
}
```

#### 5.3 Playerクラスの実装
1. `Player`クラスを作成し、`name`と`hand`フィールドを定義します。
2. コンストラクタを実装し、`name`を初期化します。
3. `showHand()`メソッドを実装し、手札を表示します。
4. `exchangeCards()`メソッドを実装し、カードを交換します。

```java
import java.util.*;

public class Player {
    private String name;
    private List<Card> hand;

    public Player(String name) {
        this.name = name;
        this.hand = new ArrayList<>();
    }

    public void showHand() {
        for (Card card : hand) {
            System.out.print(card + " ");
        }
        System.out.println();
    }

    public void exchangeCards(Deck deck, List<Integer> cardIndices) {
        for (int index : cardIndices) {
            hand.set(index, deck.dealCard());
        }
    }

    public List<Card> getHand() {
        return hand;
    }

    public void addCard(Card card) {
        hand.add(card);
    }
}
```

#### 5.4 PokerGameクラスの実装
1. `PokerGame`クラスを作成し、`player`, `computer`, `deck`フィールドを定義します。
2. `startGame()`メソッドを実装し、ゲームを開始します。
3. `dealInitialCards()`メソッドを実装し、初期の手札を配ります。
4. `playerTurn()`メソッドを実装し、プレイヤーのターンを処理します。
5. `computerTurn()`メソッドを実装し、コンピュータのターンを処理します。
6. `determineWinner()`メソッドを実装し、勝者を決定します。

```java
import java.util.*;

public class PokerGame {
    private Player player;
    private Player computer;
    private Deck deck;

    public PokerGame(String playerName) {
        player = new Player(playerName);
        computer = new Player("Computer");
        deck = new Deck();
        deck.shuffle();
    }

    public void startGame() {
        dealInitialCards();
        playerTurn();
        computerTurn();
        determineWinner();
    }

    private void dealInitialCards() {
        for (int i = 0; i < 5; i++) {
            player.addCard(deck.dealCard());
            computer.addCard(deck.dealCard());
        }
    }

    private void playerTurn() {
        System.out.println("Your hand:");
        player.showHand();
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter the indices of the cards you want to exchange (0-4, separated by spaces):");
        String[] indices = scanner.nextLine().split(" ");
        List<Integer> cardIndices = new ArrayList<>();
        for (String index : indices) {
            cardIndices.add(Integer.parseInt(index));
        }
        player.exchangeCards(deck, cardIndices);
        System.out.println("Your new hand:");
        player.showHand();
    }

    private void computerTurn() {
        Random random = new Random();
        int numCardsToExchange = random.nextInt(3) + 1;
        List<Integer> cardIndices = new ArrayList<>();
        for (int i = 0; i < numCardsToExchange; i++) {
            cardIndices.add(random.nextInt(5));
        }
        computer.exchangeCards(deck, cardIndices);
    }

    private void determineWinner() {
        // 手札の強さを比較して勝者を決定するロジックを実装
        // ここでは簡単にランダムで勝者を決定します
        Random random = new Random();
        if (random.nextBoolean()) {
            System.out.println(player.getName() + " wins!");
        } else {
            System.out.println(computer.getName() + " wins!");
        }
    }
}
```

### 6. 提出方法
1. 実装が完了したら、ソースコードをGitHubの公開リポジトリにアップロードしてください。
2. リポジトリのURLをメールで提出してください。

この仕様書に従って、ポーカーゲームアプリケーションを実装してください。質問がある場合は、遠慮なくお問い合わせください。