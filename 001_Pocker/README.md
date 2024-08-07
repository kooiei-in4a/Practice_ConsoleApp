## �ۑ�d�l��: �R���\�[����ł̃|�[�J�[�Q�[���A�v���P�[�V����

### 1. �T�v
���̉ۑ�ł́AJava���g�p���ăR���\�[���A�v���P�[�V�����Ƃ��ē��삷��|�[�J�[�Q�[�����������܂��B�v���C���[�̓R���s���[�^�Ƒΐ킵�A��D�̋����������܂��B�ŏI�I�ȃ\�[�X�R�[�h��GitHub�̌��J���|�W�g���ɔz�u���A����URL�����[���Œ�o���Ă��������B

### 2. �Q�[���̃��[��
- �g�p����|�[�J�[�̃��[���́u5�J�[�h�h���[�v�ł��B
- �v���C���[�ƃR���s���[�^�͂��ꂼ��5���̃J�[�h�������܂��B
- �v���C���[��1�񂾂��J�[�h�������ł��܂��B
- �ŏI�I�Ȏ�D�̋������r���A���҂����肵�܂��B

### 3. �v���@�\

#### 3.1 �Q�[���J�n
- �Q�[���J�n���Ƀv���C���[�ɖ��O����͂����܂��B
- �g�����v�̃f�b�L���V���b�t�����A�v���C���[�ƃR���s���[�^��5�����J�[�h��z��܂��B

#### 3.2 �J�[�h�̕\��
- �v���C���[�̎�D���R���\�[���ɕ\�����܂��B
- �J�[�h�́u2H�i2 of Hearts�j�v�̂悤�ɕ\�����܂��B

#### 3.3 �J�[�h����
- �v���C���[��1�񂾂��C�ӂ̖����̃J�[�h�������ł��܂��B
- ��������J�[�h�̔ԍ�����͂����A�V�����J�[�h��z��܂��B

#### 3.4 �R���s���[�^�̓���
- �R���s���[�^�̓����_����1�`3���̃J�[�h���������܂��B

#### 3.5 ���҂̌���
- �ŏI�I�Ȏ�D�̋������r���A���҂����肵�܂��B
- ���҂̖��O�Ǝ�D��\�����܂��B

### 4. �N���X�݌v

#### 4.1 Card�N���X
- �t�B�[���h: `suit`�i�X�[�g�j, `rank`�i�����N�j
- ���\�b�h: �R���X�g���N�^, `toString()`

#### 4.2 Deck�N���X
- �t�B�[���h: `cards`�i�J�[�h�̃��X�g�j
- ���\�b�h: �R���X�g���N�^, `shuffle()`, `dealCard()`

#### 4.3 Player�N���X
- �t�B�[���h: `name`�i���O�j, `hand`�i��D�j
- ���\�b�h: �R���X�g���N�^, `showHand()`, `exchangeCards()`

#### 4.4 PokerGame�N���X
- �t�B�[���h: `player`�i�v���C���[�j, `computer`�i�R���s���[�^�j, `deck`�i�f�b�L�j
- ���\�b�h: `startGame()`, `dealInitialCards()`, `playerTurn()`, `computerTurn()`, `determineWinner()`

### 5. �����菇

#### 5.1 Card�N���X�̎���
1. `Card`�N���X���쐬���A`suit`��`rank`�t�B�[���h���`���܂��B
2. �R���X�g���N�^���������A`suit`��`rank`�����������܂��B
3. `toString()`���\�b�h���I�[�o�[���C�h���A�J�[�h�̕\���`�����`���܂��B

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

#### 5.2 Deck�N���X�̎���
1. `Deck`�N���X���쐬���A`cards`�t�B�[���h���`���܂��B
2. �R���X�g���N�^��52���̃J�[�h�𐶐����A`cards`���X�g�ɒǉ����܂��B
3. `shuffle()`���\�b�h���������A�f�b�L���V���b�t�����܂��B
4. `dealCard()`���\�b�h���������A�f�b�L����1���̃J�[�h�����o���܂��B

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

#### 5.3 Player�N���X�̎���
1. `Player`�N���X���쐬���A`name`��`hand`�t�B�[���h���`���܂��B
2. �R���X�g���N�^���������A`name`�����������܂��B
3. `showHand()`���\�b�h���������A��D��\�����܂��B
4. `exchangeCards()`���\�b�h���������A�J�[�h���������܂��B

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

#### 5.4 PokerGame�N���X�̎���
1. `PokerGame`�N���X���쐬���A`player`, `computer`, `deck`�t�B�[���h���`���܂��B
2. `startGame()`���\�b�h���������A�Q�[�����J�n���܂��B
3. `dealInitialCards()`���\�b�h���������A�����̎�D��z��܂��B
4. `playerTurn()`���\�b�h���������A�v���C���[�̃^�[�����������܂��B
5. `computerTurn()`���\�b�h���������A�R���s���[�^�̃^�[�����������܂��B
6. `determineWinner()`���\�b�h���������A���҂����肵�܂��B

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
        // ��D�̋������r���ď��҂����肷�郍�W�b�N������
        // �����ł͊ȒP�Ƀ����_���ŏ��҂����肵�܂�
        Random random = new Random();
        if (random.nextBoolean()) {
            System.out.println(player.getName() + " wins!");
        } else {
            System.out.println(computer.getName() + " wins!");
        }
    }
}
```

### 6. ��o���@
1. ����������������A�\�[�X�R�[�h��GitHub�̌��J���|�W�g���ɃA�b�v���[�h���Ă��������B
2. ���|�W�g����URL�����[���Œ�o���Ă��������B

���̎d�l���ɏ]���āA�|�[�J�[�Q�[���A�v���P�[�V�������������Ă��������B���₪����ꍇ�́A�����Ȃ����₢���킹���������B