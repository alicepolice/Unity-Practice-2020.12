using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{
    delegate void Del();

    delegate void Del2(string a);

    delegate string Del3(string b);
    void Start()
    {
        #region lambda
        // => Goes to 
        Del del = delegate() {print("HelloWorld"); };

        Del del2 = () => { };

        Del2 del3 = delegate(string item) { print(item); };

        Del2 del4 = (string item) => { print(item); };
        // lambda 可以推断出你的参数类型
        del4 = (str) => { print(str); };

        Del3 del5 = delegate(string item)
        {
            item = item.ToUpper();
            return item;
        };

        Del3 del6 = (item) =>
        {
            item = item.ToUpper();
            return item;
        };
        #endregion
    }
}
