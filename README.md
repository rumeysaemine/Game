# 3D Oyun
## Oynanış
Biricik bridge platformlar arası geçiş oyunudur. Oyunda platformlar arasındaki mesafeye göre köprü boyutu ayarlanır ve oyuncunun düşmeden karşı platforma geçmesi sağlanır. Oyunu oynamak için *[buraya](https://simmer.io/@RumeysaEmine/biricik-bridge)* tıklayınız.

## Tuşlar
Oyun space ve sağ ok tuşu kullanılarak oynanır. Köprü boyutu space tuşuyla ayarlandıktan sonra sağ ok tuşuyla köprü karşı platforma yerleştirilir. ESC tuşu durdurma menüsünü açıp kapatmak için kullanılır. 

## Oyun İçi Görsel
![](https://github.com/rumeysaemine/Game/blob/main/image/Oyun1.jpg)
![](https://github.com/rumeysaemine/Game/blob/main/image/Oyun2.jpg)

### Bridge_sc.cs
---
Space tuşuyla köprü boyutunun ayarlanması:
```
if(Input.GetAxisRaw("Jump") == 1f && turnCount == 1)
{
    transform.localScale += new Vector3(0f,0.2f,0f);
} 
```
Köprü boyutunun y ekseni boyunca tek yönden uzaması için köprü nesnesinin merkez noktasını değiştirmemiz gerekti. Bunun için boş GameObject oluşturduk ve buna köprü nesnesini child nesne olarak verdik.

Sağ ok tuşuyla köprünün karşı platforma yerleştirilmesi:
```
else if(Input.GetAxisRaw("Jump") == -1f)
{
    turn = true;
    if(turn == true && turnCount == 1)
    {
        transform.rotation = transform.rotation * Quaternion.Euler(0,0,-90);
        turn = false;
        turnCount -= 1;             
    }
}
```
turn değişkenini köprünün yalnızca bir kez dönmesini kontrol etmek için turnCount değişkenini ise köprünün döndürüldükten sonra boyutunun değiştirilmesini engellemek için kullandık. 

Köprü karşı platforma yerleştirildikten sonra oyuncunun otomatik hareketi:
```
if(turnCount == 0)
{
    playerControl.transform.Translate(Vector3.right * Time.deltaTime * playerScript.speed); 
}
```

### Player_sc.cs
---
Bu script dosyasında durdurma menüsü için gerekli olan buton aksiyonlarını tanımladık.
![](https://github.com/rumeysaemine/Game/blob/main/image/Oyun3.jpg)

Ayrıca oyuncunun karşı platform zeminine değdiği zaman durması için aşağıdaki kodu yazdık.
```
private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Target"){
            speed = 0f;
        }   
    }
```

## Oyun Linki:
https://simmer.io/@RumeysaEmine/biricik-bridge

## Hazırlayanlar
* Eda DURAL
* Rumeysa Emine ŞAHİN
