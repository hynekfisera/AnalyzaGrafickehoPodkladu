# Analýza grafického podkladu-rastrová grafika
Úkolem je vytvořit software pro analýzu grafického podkladu. Podkladem je obrázek rastrové grafiky například mapový výřez, letecký snímek nebo nakreslené obrysy budov, cest, parcel a pod. Aplikace bude obsahovat tlačítko pro načtení obrázku. Dále pak bude obsahovat nástroj pro načtení měřítka. Například myší vyberu vzdálenost na mapě v textboxu zadám kolika metrům to odpovídá ve skutečnosti.

Aplikace použije pro zpřesnění bodu skenování podkladu(najde roh v okolí pomocí GetPixel nebo lepším způsobem).

Program předpokládá přímé úseky mezi body. Analyzovaný tvar parcely je zadáván postupným klikáním myší po mapě (obecný n-úhelník). Pro výpočet můžete použít Gaussovu metodu pro obecný mnohoúhelník s nekřížícími stranami. 


Aplikace bude průběžně při zadávání vykonávat:
- barevné vykreslení spojnice vybraných bodů
- zobrazení souřadnice posledního vybraného bodu 
- zobrazení vzdálenosti mezi posledním a předposledním vybraným bodem 
-	zobrazení obvodu vybraného mnohoúhelníku
-	zobrazení plochy vybraného mnohoúhelníku
-	zobrazení celkové plochy od začátku spuštěné operace

Pomocí této aplikace půjde změřit několik oblastí najednou(vyberu prví do které se vykreslí informace zmíněné výše). Poté co ukončím výběr budu moci začít výběr nového mnohoúhelníku.

Aplikace umožní následnou editaci zadaných mnohoúhelníků.
-	Editace jednotlivých rohů
-	Ruční úprava
-	Automatické zpřesnění

Dále bude aplikace umožňovat export/import zadaných mnohoúhelníku.

Mapa k dispozici na: [http://nahlizenidokn.cuzk.cz/](http://nahlizenidokn.cuzk.cz/)
