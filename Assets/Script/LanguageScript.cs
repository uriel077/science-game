using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LanguageScript : MonoBehaviour {

	public static LanguageScript S;
	public string returnWord;
	private string Language;
	void Start () {
		intiallang ();
	}
	public void intiallang()
	{
		S = this;

		if (PlayerPrefs.GetString ("language") != null&&PlayerPrefs.GetString ("language") != "") {
			Language = PlayerPrefs.GetString ("language");
		} else {
			Language = Application.systemLanguage.ToString ();
			PlayerPrefs.SetString ("language",Application.systemLanguage.ToString ());
			
		}
        PlayerPrefs.SetString("French", "français");
        PlayerPrefs.SetString("Hebrew", Reverse("עברית"));
        PlayerPrefs.SetString("Russian", "русский");
        PlayerPrefs.SetString("English", "English");
        PlayerPrefs.SetString("Arabic", Reverse("العربية "));
        if (Language == "Hebrew")
        {
            PlayerPrefs.SetString("resume", "????");
            PlayerPrefs.SetString("restart", "???");
            PlayerPrefs.SetString("exit", Reverse("היציאה"));
            PlayerPrefs.SetString("tapthebutton", Reverse("תלחץ על הכפתור"));
            PlayerPrefs.SetString("useparachute", Reverse("תשתמש במצנח"));
            PlayerPrefs.SetString("back", Reverse("חזור"));
            PlayerPrefs.SetString("etc", "??");
            PlayerPrefs.SetString("credit1", Reverse("תודות"));
            PlayerPrefs.SetString("creditt", Reverse("מפתח:אוריאל חג'ג'"));
            PlayerPrefs.SetString("menu", Reverse("תפריט"));
            PlayerPrefs.SetString("next", Reverse("הבא"));
            PlayerPrefs.SetString("previous", Reverse("הקודם"));
            PlayerPrefs.SetString("levels", Reverse("שלבים"));
            PlayerPrefs.SetString("endtext3", Reverse("עוד מסה עוד התנגדות"));
            PlayerPrefs.SetString("level2m", Reverse("כוח המשיכה בשלב זה ניתן לראות שלא מופעל על הגוף שום כוח משיכה" + "השאר העצמים ביקום לכיוונו כוח זה נקרא  "+" כל עצם ביקום מפעיל כוח שמושך את"));
            PlayerPrefs.SetString("level3m", Reverse("  שלב זה הגדלנו את מסת הדמות פי חמישים . שהגדיל את התנגדות ומכך הדמות האטה "));
            PlayerPrefs.SetString("level4m", Reverse(" הקטנו את מסת הדמות ולכן שאנחנו מפעילים אותה כמות כוח אז היא זזה מהר יותר "));
            PlayerPrefs.SetString("level5m", Reverse(" הקטנו את כוח המשיכה ולכן שהדמות קופצת היא קופצת גבוה יותר "));
            PlayerPrefs.SetString("level6m", Reverse(" את השער ע'י הפעלה וכיבוי המתג" + "\n" + "כדי לעבור את השלב צריך לפתוח"));
            PlayerPrefs.SetString("level7m", Reverse("יהפוך את פעילות המתג") + "Not");
            PlayerPrefs.SetString("level8m", "And-" + "\n" + Reverse(" יהיו דולקים כדי שהשער יפתח" + "\n" + "צריך ששני המתגים"));
            PlayerPrefs.SetString("level9m", "Or-" + "\n" + Reverse(" מספיק שאחד המתגים יפעל כדי לפתוח את השער "));
            PlayerPrefs.SetString("level10m", "Nor-" + "\n" + Reverse("רק כששני המתגים כבויים אז השער ניפתח"));
            PlayerPrefs.SetString("level11m", "Nand-" + "\n" + Reverse("השער יפתח אם שני המתגים לא דולקים"));
            PlayerPrefs.SetString("level12m", "Xor-" + "\n" + Reverse(" השער יפתח בתנאי שאחד המתגים דולק ואחד המתגים כבוי"));
            PlayerPrefs.SetString("level13m", "Exor-" + "\n" + Reverse(" השער יפתח בתנאי שאו ששני המתגים דולקים או ששני המתגים כבויים"));
            PlayerPrefs.SetString("level14m", Reverse("מושכים (+ מושך -)צדדים זהים דוחים (+ דוחה +, - דוחה -) מגנטיות" + "\n" + " למגנט יש שני קטבים (צדדים) צד חיובי ושלילי צדדים מנוגדים של המגנט"));
            PlayerPrefs.SetString("level15m", Reverse("ציפה / ריחוף - כמו שהסברנו קודם לכל עצם ביקום יש מסה(כמות החומר ממנו עשוי העצם) כולל מים ואויר.אם הצפיפות של עצם קטנה משל מים אז העצם יצוף. "));
            PlayerPrefs.SetString("level16m", Reverse(" "));
            PlayerPrefs.SetString("level17m", Reverse(" בשלב זה הדמות הפכה לכדור אלסטי וכל כוח שמפעיל על עצם חוזר בכיוון ההפוך באותה עוצמה "));
            PlayerPrefs.SetString("level18m", Reverse("המאוורר פולט אוויר שכאשר פוגע בדמות היא עולה למעלה  "));
            PlayerPrefs.SetString("level19m", Reverse("תנועה הרמונית זו תנועה שהגוף תמיד מנסה להגיע לנקודת שיווי משקל מטוטלת מבצעת תנועה זאת ומנסה תמיד להגיע למרכז  "));

            PlayerPrefs.SetString("level20m", Reverse("מושכים (+ מושך -)צדדים זהים דוחים (+ דוחה +, - דוחה -) מגנטיות למגנט יש שני קטבים (צדדים) צד חיובי ושלילי צדדים מנוגדים של המגנט"));
            PlayerPrefs.SetString("level21m", Reverse(" לייזר הינו קרון אור מרוכז ועוצמתי בעל אורך גל בודד "));
            PlayerPrefs.SetString("level22m", Reverse(" חיישן קולט את הגל האור הספציפי ופעול לפיו "));
            PlayerPrefs.SetString("level23m", Reverse("כמו כל קרן אור לייזר עובר דרך דברים שקופים כגון זכוכית"));
            PlayerPrefs.SetString("level24m", Reverse("נחסם ע'י חפצים שאינם שקופים כגון קיר ,לבנה ,קופסה."));
            PlayerPrefs.SetString("level25m", Reverse("כמו כל קרן אור לייזר מוחזר ממראות .   קרן האור ,הלייזר מוחזר מהמראה בזווית הזהה לזו שהו שהוא פגע במראה ."));
            PlayerPrefs.SetString("level26m", Reverse(" בשלב זה מסמל את הנוגדנים שהגוף מייצר לחסל את החיידקים ,רואים שלגוף קשה להסתדר לבדו "));
            PlayerPrefs.SetString("level27m", Reverse(" הכדור הלבן מייצג אנטיביוטיקה ומזיק לחיידקים ולא לדמות ובעזרתו הוא מחסל אותם בקלות יותר "));
            PlayerPrefs.SetString("level28m", Reverse(" אנו רואים מאזניים וכאשר יש יותר משקל בצד אחד המאזניים מוטים כלפיו "));
            PlayerPrefs.SetString("level29m", Reverse(" בשלב זה אנו מזיזי את הציר וכאשר אנו מתקרבים לציר כך יותר קשה להרים את הצד השני אך כאשר מתרחקים אנו רואים שביתר קלות אנו מזיזים את צד זה אפקט זה נקרא חוק המנוף "));
            PlayerPrefs.SetString("level30m", Reverse(" המיצנח מגדיל את שטח הפנים של הדמות ובכך מקטן את הצפיפת היחסית של הדמות ולכן הדמות נופלת לעת יותר"));
            PlayerPrefs.SetString("languages", Reverse("שפות"));
            /*PlayerPrefs.SetString ("Hebrew", Reverse("עברית"));
			PlayerPrefs.SetString ("English", "תילגנא");
			PlayerPrefs.SetString ("Russian","תיסור");
			PlayerPrefs.SetString ("French","français");
			PlayerPrefs.SetString ("Arabic","Arabic");*/
            PlayerPrefs.SetString("changelanguage", Reverse("שינוי שפה"));

            PlayerPrefs.SetString("endlesslevel", Reverse("שלב אין סופי"));

        }
        else if (Language == "Russian")
        {
            PlayerPrefs.SetString("resume", "????");
            PlayerPrefs.SetString("restart", "перезапустить");
            PlayerPrefs.SetString("exit", "выход");
            PlayerPrefs.SetString("etc", "и т.д");
            PlayerPrefs.SetString("credit1", "уважение к:");
            PlayerPrefs.SetString("creditt", " Разработкчик:  уриэль хаджадж");
            PlayerPrefs.SetString("menu", "меню");
            PlayerPrefs.SetString("next", "следующей");
            PlayerPrefs.SetString("previous", "предыдущий");
            PlayerPrefs.SetString("levels", "уровни");
            PlayerPrefs.SetString("endtext3", " ??????? ???, ??? ???");
            PlayerPrefs.SetString("endtext10", " ??????? ???, ??? ???");
            PlayerPrefs.SetString("level3m", "ты весишь в 500 раз больше чем раньше не так просто как кажытся");
            PlayerPrefs.SetString("level15m", "плавать / парить - как мы объясняли  раньше у каждыго  предмета есть маса (каличестго материи из которого состаит предмет) включает в себя воду, воздух и тд. если плотность предмета меньше чем у то предмет будет плыть на воде  ");

            PlayerPrefs.SetString("level5m", " ?? ????? ???? ??? , ???? ?? ??????? ????");
            PlayerPrefs.SetString("level6m", "???? ??");
            PlayerPrefs.SetString("level7m", " ???? ??? ??? ?? ?? \n ??? ?????? ?????? 500 ?? ???? ???");
            PlayerPrefs.SetString("level8m", "???? ??");

            PlayerPrefs.SetString("level14m", "магнит имеет два полюса (стороны) положительный и отрицательный.  противоположные друг другу стороны магнита  -(притягиваются+) одни и те же стороны  (+отталкиваются +,)\n\t");
            PlayerPrefs.SetString("level6m", " Чтобы пройти уровень нужно открыть ворота при помощи включения и выключения");
            PlayerPrefs.SetString("level7m", "Not- переворачивает работу переключателя");
            PlayerPrefs.SetString("level8m", "And – нужны два горящих переключателя чтобы ворота открылись");
            PlayerPrefs.SetString("level9m", "Or – достаточно чтобы ворота открылись");
            PlayerPrefs.SetString("level10m", " Nor- только когда оба переключателя выключены ворота откроются ");
            PlayerPrefs.SetString("level11m", "Nand – ворота откроются если хотя бы один переключатель выключен");
            PlayerPrefs.SetString("level12m", "Xor- ворота откроются если один переключатель выключен и один включен ");
            PlayerPrefs.SetString("level13m", "Exor- ворота откроются если оба переключателя включены или обо выключены");
            PlayerPrefs.SetString("level23m", " Как любой луч света лазер проходит сквозь прозрачные вещи как стекло и блокируется при");
            PlayerPrefs.SetString("level24m", "помощи не прозрачных вещей как стена кирпич или коробка.");
            PlayerPrefs.SetString("level25m", "Как любой луч света лазер отражает зеркало.  Луч света отражается от зеркала в градусе, который равен тому в каком он попал в стекло. ");

            /*PlayerPrefs.SetString ("languages", "языки");
			PlayerPrefs.SetString ("Hebrew","иврит");
			PlayerPrefs.SetString ("English", "английский");
			PlayerPrefs.SetString ("Russian","русский");
			PlayerPrefs.SetString ("French","французский");
			PlayerPrefs.SetString ("Arabic","Arabic");*/

            PlayerPrefs.SetString("changelanguage", "изменить язык");

        }
        else if (Language == "Arabic")
        {
            PlayerPrefs.SetString("resume", "????");
            PlayerPrefs.SetString("restart", "перезапустить");
            PlayerPrefs.SetString("exit", "выход");
            PlayerPrefs.SetString("etc", "и т.д");
            PlayerPrefs.SetString("credit1", "ائتمان");
            PlayerPrefs.SetString("creditt", " Разработкчик:  уриэль хаджадж");
            PlayerPrefs.SetString("menu", "меню");
            PlayerPrefs.SetString("next", "следующей");
            PlayerPrefs.SetString("previous", "предыдущий");
            PlayerPrefs.SetString("levels", "уровни");
            PlayerPrefs.SetString("endtext3", " ??????? ???, ??? ???");
            PlayerPrefs.SetString("endtext10", " ??????? ???, ??? ???");
            PlayerPrefs.SetString("level3m", " ???? ??? ??? ?? ?? \n ??? ?????? ?????? 500 ?? ???? ???");
            PlayerPrefs.SetString("level4m", " ????? ?????? ???? ???? ??? , ????? ??????");
            PlayerPrefs.SetString("level5m", " ?? ????? ???? ??? , ???? ?? ??????? ????");
            PlayerPrefs.SetString("level6m", "???? ??");
            PlayerPrefs.SetString("level7m", " ???? ??? ??? ?? ?? \n ??? ?????? ?????? 500 ?? ???? ???");
            PlayerPrefs.SetString("level8m", "???? ??");
            PlayerPrefs.SetString("level10m", "???? ??");
            PlayerPrefs.SetString("level14m", "магнит имеет два полюса (стороны) положительный и отрицательный.  противоположные друг другу стороны магнита  -(притягиваются+) одни и те же стороны  (+отталкиваются +,)\n\t");

            /*PlayerPrefs.SetString ("languages", "языки");
			PlayerPrefs.SetString ("Hebrew","иврит");
			PlayerPrefs.SetString ("English", "английский");
			PlayerPrefs.SetString ("Russian","русский");
			PlayerPrefs.SetString ("French","français");
			PlayerPrefs.SetString ("Arabic","Arabic");*/
            PlayerPrefs.SetString("changelanguage", "изменить язык");

        }
        else if (Language == "French")
        {
            PlayerPrefs.SetString("resume", "????");
            PlayerPrefs.SetString("restart", "recommencer");
            PlayerPrefs.SetString("exit", "Fermer");
            PlayerPrefs.SetString("exit", "arrière");
            PlayerPrefs.SetString("etc", "etc");
            PlayerPrefs.SetString("credit1", "crédit:");
            PlayerPrefs.SetString("creditt", " Développeur: Uriel Hajaj");
            PlayerPrefs.SetString("menu", "menu");
            PlayerPrefs.SetString("next", "Suivant");
            PlayerPrefs.SetString("previous", "précédent");
            PlayerPrefs.SetString("levels", "les niveaux");
            PlayerPrefs.SetString("endtext3", " ??????? ???, ??? ???");
            PlayerPrefs.SetString("endtext10", " ??????? ???, ??? ???");
            PlayerPrefs.SetString("level3m", " ???? ??? ??? ?? ?? \n ??? ?????? ?????? 500 ?? ???? ???");
            PlayerPrefs.SetString("level4m", " ????? ?????? ???? ???? ??? , ????? ??????");
            PlayerPrefs.SetString("level5m", " ?? ????? ???? ??? , ???? ?? ??????? ????");
            PlayerPrefs.SetString("level6m", "???? ??");
            PlayerPrefs.SetString("level7m", " ???? ??? ??? ?? ?? \n ??? ?????? ?????? 500 ?? ???? ???");
            PlayerPrefs.SetString("level8m", "???? ??");
            PlayerPrefs.SetString("level10m", "???? ??");
            PlayerPrefs.SetString("languages", "Langues");
            /*PlayerPrefs.SetString ("Hebrew","hébreu");
			PlayerPrefs.SetString ("English", "Anglais");
			PlayerPrefs.SetString ("Russian","russe");
			PlayerPrefs.SetString ("French","français");
			PlayerPrefs.SetString ("Arabic","Arabic");*/
            PlayerPrefs.SetString("changelanguage", "Changer de langue");

            PlayerPrefs.SetString("level14m", "aimant a deux pôles (main) positifs et négatifs. des côtés mutuellement opposés de l'aimant - (+ attirés) du même côté (+ repousser +)\n\t");
            PlayerPrefs.SetString("level6m", "Pour déplacer la scène pour ouvrir la porte par la marche et arrêt");
            PlayerPrefs.SetString("level7m", "גתמה תוליעפ תא ךופהי-Not");
            PlayerPrefs.SetString("level8m", "And - vous avez deux commutateurs seront allumés pour ouvrir la porte");
            PlayerPrefs.SetString("level9m", "Or - assez que l'un des commutateurs fonctionnera pour ouvrir la porte");
            PlayerPrefs.SetString("level10m", "Nor - que lorsque les deux interrupteurs sont désactivés pour l'objectif Ouvert ");
            PlayerPrefs.SetString("level11m", "Nand - porte ouverte, sinon deux interrupteurs éclairés");
            PlayerPrefs.SetString("level12m", "Xor- porte ouvre à la condition que l'un des interrupteurs et coupe une");
            PlayerPrefs.SetString("level13m", "Exor - la porte ouvre à la condition que l'un ou les deux commutateurs sont sur les deux commutateurs sont éteints");
            PlayerPrefs.SetString("level20m", "טנגמה לש םידגונמ םידדצ ילילשו יבויח דצ )םידדצ( םיבטק ינש שי טנגמל תויטנגמ -)\n החוד - +, החוד (+ םיחוד םיהז םידדצ)- ךשומ (+ םיכשומ\n");
            PlayerPrefs.SetString("level23m", "Comme pour tout faisceau de lumière laser passe au travers des choses transparents tels que le verre");
            PlayerPrefs.SetString("level24m", "Bloqué par les objets non transparents, telle qu'un mur, une zone blanche.");
            PlayerPrefs.SetString("level25m", "Comme pour tout faisceau réfléchi de lumière laser miroirs. Faisceau, le laser a été ramené au même niveau que quelque chose qui a frappé le miroir");
            PlayerPrefs.SetString("endlesslevel", "Niveau sans fin");

        }
        else
        {
            PlayerPrefs.SetString("resume", "Resume");
            PlayerPrefs.SetString("restart", "Restart");
            PlayerPrefs.SetString("exit", "Exit");
            PlayerPrefs.SetString("tapthebutton", "tap the button");
            PlayerPrefs.SetString("useparachute", "use parachute");
            PlayerPrefs.SetString("back", "Back");
            PlayerPrefs.SetString("etc", "ETC");
            PlayerPrefs.SetString("stats", "Stats");
            PlayerPrefs.SetString("credit1", "Credit");
            PlayerPrefs.SetString("creditt", "Developer : Uriel Hajaj ");
            PlayerPrefs.SetString("menu", "Menu");
            PlayerPrefs.SetString("next", "Next");
            PlayerPrefs.SetString("previous", "Previous");
            PlayerPrefs.SetString("levels", "Levels");
            PlayerPrefs.SetString("endtext3", "more mass more resistence");
            PlayerPrefs.SetString("languages", "Languages");
            /*PlayerPrefs.SetString ("Hebrew","Hebrew");
			PlayerPrefs.SetString ("English", "English");
			PlayerPrefs.SetString ("Russian","Russian");
			PlayerPrefs.SetString ("French","French");
			PlayerPrefs.SetString ("Arabic","Arabic");*/
            PlayerPrefs.SetString("changelanguage", "Change Language");
            PlayerPrefs.SetString("endlesslevel", "Endless level");
            PlayerPrefs.SetString("level3m", "your mass is multiply by 500\n not easy like it look like  ");
            PlayerPrefs.SetString("level4m", "high speed ,win before you gonna blink ");
            PlayerPrefs.SetString("level5m", "touch ths star you cant , but touch the sky you can ");
            PlayerPrefs.SetString("level6m", "In order to pass this level you must open the gate by turning the switch on and off.");
            PlayerPrefs.SetString("level7m", "NOT gate- reverses the switch's state.");
            PlayerPrefs.SetString("level8m", "AND gate- both switches must be turned on in order to open the gate.");
            PlayerPrefs.SetString("level9m", "OR gate- one switch turned on is enough to open the gate.");
            PlayerPrefs.SetString("level10m", "NOR gate- the gate will open only when neither switch is turned on.");
            PlayerPrefs.SetString("level11m", "NAND gate- the gate will not open only when both switches are turned on.");
            PlayerPrefs.SetString("level12m", "XOR gate- the gate will open only if one switch is turned on and one is turned off.");
            PlayerPrefs.SetString("level13m", "EXOR gate- the gate will open only if both switches are turned on or if both gates are turned off.");
            PlayerPrefs.SetString("level14m", Reverse("מושכים (+ מושך -)צדדים זהים דוחים (+ דוחה +, - דוחה -) מגנטיות" + "\n" + " למגנט יש שני קטבים (צדדים) צד חיובי ושלילי צדדים מנוגדים של המגנט"));
            PlayerPrefs.SetString("level20m", Reverse("מושכים (+ מושך -)צדדים זהים דוחים (+ דוחה +, - דוחה -) מגנטיות למגנט יש שני קטבים (צדדים) צד חיובי ושלילי צדדים מנוגדים של המגנט"));
            PlayerPrefs.SetString("level23m", "As with all light, laser passes through transparent matter such as glass");
            PlayerPrefs.SetString("level24m", "is blocked and absorbed by matter that is not transpaprent such as a wall, a building block or a box");
            PlayerPrefs.SetString("level25m", Reverse("כמו כל קרן אור לייזר מוחזר ממראות .   קרן האור ,הלייזר מוחזר מהמראה בזווית הזהה לזו שהו שהוא פגע במראה ."));

        }
    }
	public string ReturnWord(string word)
	{
		returnWord = PlayerPrefs.GetString (word);
		return returnWord;
	}
	public string ReturnWordend(string word,int levelnum)
	{
		returnWord = PlayerPrefs.GetString (word+levelnum);
		return returnWord;
	}

	public string Reverse(string text)
	{
		char[] cArray = text.ToCharArray();
		string reverse = "";
		for (int i = cArray.Length - 1; i > -1; i--)
		{
			//if(cArray[i]>'Z'||cArray[i]==' ')
			reverse += cArray[i];
		}
		return reverse;
	}
}