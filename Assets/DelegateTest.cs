using UnityEngine;

// Делегаты - это указатели на методы.

delegate void Message();
public class DelegateTest : MonoBehaviour
{
    // Объявление делегата
    void Hello() => print("Hello World");

    private void Awake()
    {
        Message _message = new Message(Hello);
        _message();
    }
    
    // Делегаты необязательно могут указывать только на методы, которые определены
    // В том же классе, где определена переменная делегата. Это могут быть также методы
    // из других классов и структур.

    private void Start()
    {
        Message _message = GetComponent<AnonymDelegate>().Text;
        _message();
    }
    
    // Делегаты можно определять в конце кода, но в принципе делегат можно определить
    // внутри класса. 
}
