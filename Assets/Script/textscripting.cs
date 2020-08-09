using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class textscripting : MonoBehaviour {
	public LanguageScript languageScript;
	public string Word;
	void OnEnable()
	{
		try{
			string tempWord = transform.gameObject.name;
			if(tempWord!="endtext")
			{
			Word = LanguageScript.S.ReturnWord (tempWord);

			}else
			{
				Word = LanguageScript.S.ReturnWordend (tempWord,Application.loadedLevel-1);
			}
            if (GetComponent<Text>() != null)
            
                GetComponent<Text>().text = Word;
            if (GetComponent<TextMesh>()!=null)
            GetComponent<TextMesh>().text = Word;
		}catch(Exception e){}	
	}
}
