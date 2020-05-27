# oe-geavanceerde-klassen-interfaces-gardengame-opl
Begeleide oefening op "geavanceerde klassen" en "interfaces".

# Begeleide oefening
Dit is een **begeleide oefening**. Voor de stappen uit om tot een oplossing te komen. Lees dan ook eerst goed deze opdracht door vóór je begint!

**Deze oefening vertelt je grotendeels wat je moet doen, maar niet alles wordt exact verteld.**

## Opzet
We gaan aan de slag om een mini-game te ontwerpen waarin we een eigen tuin met **planten en dieren** beheren.
De planten en dieren kunnen je een oogst opleveren die je wederom in de tuin kan gebruiken.

Enkele scenario's van wat we zullen kunnen doen:
- Scenario 1:
    - We laten gras groeien.
    - We oogsten het gras, waardoor we hooi verkrijgen
    - Dit hooi kunnen we voederen aan de koe die in onze tuin staat
- Scenario 2:
    - We geven water aan onze koe
    - De koe produceert hierdoor melk die we kunnen *oogsten*
    - In plaats van water geven we onze koe z'n eigen melk te drinken
- Scenario 3:
    - Door het drinken van water groeit onze koe
    - Door het drinken van melk, stijgt de gezondheid (`Health`) van onze koe
- Scenario 4:
    - Door het eten van gras stijgt de gezondheid van onze koe
    - In onze tuin staat echter ook een taxus, die gifbessen oplevert. Eet hij deze, dan daalt zijn gezondheid (`Health`)
    - Sommige grassoorten zijn giftig. Hierop zullen we voorzien: dit levert namelijk ook giftig hooi op!
- ...

## Before we get started ...
Wat hierboven staat is een (al) vrij uitgebreide lijst, maar het aantal lijnen code zal uiteindelijk vrij beperkt zijn!
Met deze oefening wordt namelijk het belang van **polymorfisme** aangetoond.
Zaken die ook bod komen zijn:
- **interfaces**
- **overerving**
- **abstracte klassen en methoden**
- **het `base` keyword**
- **overrides**
- ...

## Reeds beschikbare interfaces en klasses en hun functie
Deze interfaces zijn reeds ter beschikking gesteld in `Garden.Lib` in de map `Interfaces`:

|Interface|Beschijving|
|---|---|
|`IGardenItem`| Deze interface bepaalt dat een object een tuinitem is en dwingt twee methoden af: `string ShowFullInfo()` en `string ShowCompactInfo()`. Beide methodes worden gebruikt om op de GUI info weer te geven.|
|`IConsumable`| Bepaalt dat iets opgeten kan worden (Hooi, bijvoorbeeld) en dwingt de property `bool IsPoisonous`. Zo kunnen zowel giftige als niet-giftige zaken opgegeten worden.|
|`IFeedable`| Bepaalt dat iets voederbaar is. Deze dwingt de methode `void Eat(IConsumable food)` af. Alles wat `IConsumable` implementeert kunnen we dus voederen. In onze uitwerking zullen we enkel dieren voederen.|
|`IWaterable`|Bepaalt dat we iets water kunnen geven. Zowel planten als dieren zullen we water kunnen geven. Dwingt de methode `void GiveWater(int amount)` af.|
|`IHarvestable`|Bepaalt of iets geoogst kan worden. Dwingt de property `int HarvestSize { get; }` af. Deze property bepaalt hoe groot iets moet zijn vooraleer het geoogst kan worden. Daarnaast heeft deze ook de methode `Harvest GetHarvest()` om effectief een oogst te kunnen krijgen.|

Deze klassen zijn reeds ter beschikking gesteld in `Garden.Lib` in de map `Classes` > `Base`:
|Klasse|Beschijving|
|---|---|
|`Harvest`| Deze klasse bepaalt dat iets een soort oogst is. Straks zullen verschillende klassen dus overerven van deze klasse. Zo is zowel hooi als melk een `Harvest`. Merk op dat dit een `abstract class` is! (Je kan er dus geen instantie van aanmaken. Iets zal ervan over **moeten** erven.)|

# Level One: Er begint iets te groeien ...
> *Indien je het bovenstaande stuk niet las, ga dan terug naar start*.

## Superklassen voorzien
Een eerste superklasse werd reeds voorzien, namelijk de abstracte `Harvest` klasse. Maak nog twee **abstracte** klassen aan: `Plant` en `Animal`. Stop deze in de `Garden.Lib` in de `Base`-map.

Deze klassen zullen bepalen wat het betekent om een dier of plant te zijn:

De `Plant`-klasse heeft de volgende **properties**:
- `string Name`: de naam van de plant
- `bool IsPoisonous`: of hij giftig is of niet
- `int Size`: hoe groot de plant is in centimeter. Is standaard 0.

De `Plant`-klasse heeft de volgende **velden**:
- `int maxSize`: hoe groot de plant maximaal kan worden

De `Plant`-klasse ontvangt in de constructor of de plant giftig is of niet en stelt de `IsPoisonous` property in.

De `Animal`-klasse heeft de volgende **properties**:
- `string Name`: de naam van het dier
- `int Weight`: het gewicht van het dier
- `int Health`: de gezondheid, uitgedrukt in een getal, van het dier
- `int Size`: de grootte van het dier in cm

De `Animal`-klasse ontvangt in de constructor het gewicht en de grootte en stelt de properties in.

# Level 2: Eerste tuinitems maken en de tuin vullen
## De klassen opbouwen
Een tuinitem kan een plant of een dier zijn die we in de tuin plaatsen. We maken hiervoor in de map `Classes` een aantal nieuwe klassen aan: `Cow`, `Grass` en `Taxus`.

* Laat `Cow` overerven van `Animal`
* Laat `Grass` en `Taxus` overerven van `Plant`
* Voorzie de juiste `using` statements om deze klassen te kunnen referencen

Alle eigenschappen die een plant of een dier heeft, zijn nu beschikbaar in de respectievelijke klassen.

Ontvang in de constructors van `Cow`, `Grass` en `Taxus` de parameters die de basisklasse nodig geeft en geef ze door m.b.v. van het `base` keyword.

Gezien de eigenschappen van superklassen `Plant` en `Animal` ook beschikbaar zijn `Grass`, `Cow` en `Taxus` kan je de `Name` properties in hun constructor instellen. Geef de dieren hun juiste naam (koe, taxus en weidegras, bijvoorbeeld).

Voor de specifieke planten kan je dus ook in de constructor instellen wat de `maxSize` kan zijn van de plant (gedefineerd in `Plant`). Stel in de `Grass` constructor de `maxSize` in op 150. Taxus heeft een `maxSize` van 300;

## Eerste interface implementeren
Zowel `Cow`, `Grass` en `Taxus` zijn items die we in onze tuin willen kunnen plaatsen. Dit zijn dus allemaal `IGardenItems`. Implementeer bij deze klassen deze interface.

We moeten nu dus de methodes `ShowCompactInfo()` en `ShowFullInfo()` in alle drie deze klasses definiëren. Deze methodes zullen verantwoordelijk zijn om info over het object weer te geven.

Maak hiervoor eerst in beide superklassen een `public override string ToString()`.

De `Animal` superklasse returned hier gewoon de naam van het dier. De `Plant` superklasse returned ook de naam van de plant, maar geeft ook aan of de plant giftig is of niet.

Voorbeeldouput:
```
Koe
Weidegras (niet giftig)
```

Ga terug naar de specifieke tuin items en noteer in de `ShowCompactInfo()` telkens dat je de basisklasse zijn `ToString()`-methode wil gebruiken door `base.ToString()` op te roepen.

De `ShowFullInfo()` volgt dezelfde logica, maar maakt de string langer: vertel hier wat de maximale grootte en huidige grootte is.

## De tuin vullen
We hebben op dit moment drie **verschillende** klassen die allemaal de `IGardenItem` implementeren. We kunnen ze dus allemaal in onze tuin zetten.

Maak in de Codebehind een algemeen toegankelijke `List<IGardenItem>` aan en voeg in het `Window_Loaded` een `Grass`, `Cow` en `Taxus` toe en ken de lijst toe aan de  de `lstGardenItems.ItemSource`. We hebben nu een lijst van verschillende objecten! Merk op dat we de tekst kunnen lezen zoals we ze zien omdat we de `override ToString()` gebuiken.

## Details uitlezen
Wanneer op een item geklikt wordt (`lstGardenItems_SelectionChanged`), willen we de eigenschappen van elk verschillend object uit kunnen lezen. Zorg ervoor dat wanneer je op een item klikt, je de `ShowFullInfo()` van elke concrete implementatie kan oproepen zodat je de volledige info kan lezen.

Tip: elk object implementeert `IGardenItem` ...

## Water geven
Wanneer we op `btnGiveWater` klikken, willen we dat we zowel planten als dieren water kunnen geven.

Wanneer we aan een plant of een dier water geven, dan groeit het.

Laat de klassen `Plant` en `Animal` de interface `IWaterable` implementeren (die zal afdwingen dat we de `GiveWater(int amount)` methode voorzien) en zorg ervoor dat wanneer we een plant 10 liter water geven, zijn `Size` met 5 toeneemt (de helft dus).

Voor een `Cow` kiezen we echter een volledig andere aanpak. Wanneer een koe drinkt, dan groeit hij ook, maar hij produceert tevens melk!
We gaan als volgt te werk:
* Maak een property in de `Cow` klasse met de naam `NumberOfMilk`.
* Stelt in de constructor in, dat een koe standaard 0 melk heeft.
* Aangezien de `IWaterable` gedefineerd staat op het niveau van een `Animal` kan er geen melk gemaakt worden, tenzij de de verantwoordelijk overdragen naar de `Cow` klasse. De `Cow` klasse zal dan de implementatie voorzien. We doen dit door in de `Animal` klasse een abstracte methode te maken: `public abstract void GiveWater(int amount);`
Vervolgens **moet** je de specifieke implementatie in de `Cow` klasse schrijven door een `override` van deze methode te maken. Stel in deze override in dat de koe met 1 groeit en dat de helft van het ontvangen water wordt omgezet in melk (10 liter drinken = 5 liter melk).

Zowel een dier als een plant kunnen nu 'drinken'. Zorg ervoor dat wanneer op de knop `btnGiveWater` geklikt wordt, het geselecteerde item `10` water wordt geven.
Tip: De verschillende klassen implementeren de `IWaterable` interface check dan ook of het geselecteerde item een `IWaterable` ... `is`.

Zorg in de `override ToString()` er nog voor dat je kan zien hoeveel liter melk de koe momenteel heeft zitten.

Voer op dit moment in de code behind bovendien een methode `UpdateGui()` toe, zodat de lijst vernieuwd wordt wanneer je een item water gaf. Dat kan je doen met onderstaand codefragment. Zet echter wel de juiste instructie op de `???`.

```
private void UpdateGui()
{
    ??? lastItem = (???)lstGardenItems.SelectedItem; 

    lstGardenItems.ItemsSource = null;
    lstGardenItems.ItemsSource = gardenItems;

    lstGardenItems.SelectedItem = lastItem;
}
```

# Level 3: Oogsten
Hier behandelen we het concept van polymorfisme nogmaals uitdrukkelijker. We zullen zaken oogsten. Dit is onze `Harvest`. Echter, een `Harvest` kan vanalles zijn. Wanneer we gras oogsten, dan krijgen we `Hay` (hooi) en wanneer we onze koe 'oogsten', dan krijgen we `Milk` terug.

We maken een aantal nieuwe klassen: `Hay`, `Milk` en `PoisonousBerry` in de `Classes`-map. Wanneer we iets oogsten volgen we dus de volgende logica:
* `Cow` levert `Milk`
* `Grass` levert `Hay`
* `Taxus` levert `PoisonousBerry`

Gezien een `Harvest` vanalles kan zijn, voorzien we in deze klasse enkel een property `string Name`. Maak onmiddellijk ook een `override` van `ToString()` die deze teruggeeft.

Laat `Hay`, `Milk` en `PoisonousBerry` overerven van `Harvest` en stel in deze constructor de `Name` property in op een gepaste naam voor de oogst (bijvoorbeeld: melk, hooi en gifbes).

Op dit moment hebben we dus 3 verschillende klasses gemaakt van producten die aangemaakt zullen kunnen worden. Allemaal zijn het `Harvests`.

Echter, onze `Cow`, `Grass` en `Taxus` zijn nog niet 'oogstbaar'. We sluiten hiervoor eerst een contract af met de `IHarvestable` interface. Alle drie de klassen beloven dus dat ze oogstbaar zullen worden en dat ze hiervoor een implementatie voorzien.
Doe dit door naar alle drie de klassen te gaan en de `IHarvestable` interface te implementeren (deze dwingt de methode `Harvest GetHarvest()` en de property `HarvestSize` af). 

 `HarvestSize` bepaalt hoe groot iets moet zijn vooraleer we het kunnen oogsten. Bijvoorbeeld:
 * Indien de `HarvestSize` ingesteld wordt op 25 voor het gras, dan moet het gras minstens 25 cm hoog  zijn (de `Size`) vooraleer je het kan oogsten.
 * Wanneer je iets oogst is het dus dit getal dat afgetrokken wordt van de grootte van de plant (of beschikbare melk). Je hebt het er tenslotte van gehaald!


 De `HarvestSizes` zijn de volgende:
 |Type|HarvestSize|
 |---|---|
 |Taxus|15|
 |Grass|25|
 |Cow|10|

 
Zowel de `Cow`, het `Gras` en de `Taxus` hebben nu een methode (`Harvest GetHarvest()`) die een `Harvest` retourneert. Merk hierbij de kracht van polymorfisme op! Gezien zowel `Milk`, `Hay` als `PoisonousBerry` overeven van `Harvest` kunnen we deze hier dus returnen! Return bij elk een object van de juiste oogst wanneer aan de juiste codities voldaan wordt. Return `null` wanneer niet aan de conditie voldaan werd.

**Opmerking**! Een koe willen we melken, dus dit heeft geen impact op zijn `Size`, maar op `NumberOfMilk`!

Voorzie in de `ShowFullInfos()` een extra zinnetje zodat je weet hoeveel iets moet zijn voordat je het kan oogsten.

Voorzie nu in de code behind dat wanneer er op `btnHarvest` geklikt wordt, het geselecteerde item geoogst kan worden. Merk op dat we `null` returnen wanneer er niet geoogst kon worden!
Tip: alle oogstbare items implementeren `IHarvestable` en alles wat gereturned wordt is een `Harvest` (ookal is het wezenlijk, melk, hooi of een giftige bes). Plaats je oogst in de listbox `lstHarvest`.

# Level 4: Geoogste items voederen aan dieren
Op dit moment hebben we een applicatie waarin we zaken in onze tuin kunnen laten groeien en oogsten. We willen nog verder de kracht van interfaces gebruiken en willen nu dat een dier het hooi, de giftige bessen en de melk kan consumeren.

Hiervoor zullen we eerst bepalen dat sommige klassen 'opgegeten' kunnen worden met behulp van de `IConsumable` interface. Deze bepaalt dus dat iets opgeten kàn worden en dwingt een `bool IsPoisonous` af. We moeten dus vertellen of het eerbaar ding giftig is of niet ...

Implementeer `IConsumable` die een property `IsPoisonous` afdwingt op `PoisonousBerry`, `Milk` en `Hay`. Je bepaalt nu of ze giftig zijn of niet. Merk op dat dit een **andere** `IsPoisonous` is dan de plant! We hebben enerzijds een plant die bepaalt of hij giftig is en anderzijds een `IConsumable` die bepaalt of het giftig is of niet!

Voorzie ook in de specifieke 'eetbare' klasses een `override ToString()` waarin je eerst de `base` klasse aanspreekt (`Harvest`) en aan deze string toevoegt of het eetbare item giftig is of niet.

Door de interface `IConsumable` toe te passen op deze klassen hebben we dus verteld dat deze klassen eetbaar zijn en dwingen we af dat we weten of het eten giftig is of niet.

Echter, alle planten (hier gras en taxus) kàn je ook opeten (onze uitwerking zal niet voorzien dat de koe gras eet; hij eet altijd hooi). Voorzie de `IConsumable` ook in de `Plant` klasse! Merk hierbij op dat we bij de plant reeds een property `IsPoisonous` ("toevallig" dezelfde naam ...) heeft. We moeten dus verder niets doen!

**Opmerking**: we zouden kunnen redeneren dat we dieren ook kunnen eten en dat we `IConsumable` ook moeten toevoegen op `Animal`, maar dat zullen we in deze uitwerking niet doen omdat het ons te ver zou leiden ...

Toch even uitwijden ...: voor een plant moesten we daarnet al meegeven of hij giftig was of niet. We kunnen dus in de constructor van gras perfect zeggen dat we ook giftig gras willen maken. Dat betekent echter dat ook het hooi giftig moet zijn!

Voorzie in de constructor van `Hay` dat je wil ontvangen of het hooi giftig is of niet. Wanneer je de `GetHarvest()`-methode uitvoert in de klasse `Grass` ga je dus ook kijken of het gras giftig is, zodat je dit kan doorgeven aan de constructor van het `Hay` die dit zal ontvangen. De constructor van `Hay` kan vervolgens de `IsPoisonous` (afkomstig van `IEatable`) juist instellen.

De interface `IFeedable` bepaalt dat we iets eten kunnen geven (de koe voederen).
Implementeer dus op `Animal` deze interface: elk dier kan tenslotte gevoederd worden. Je ziet dat de methode die geïmplementeerd moet worden (`void Eat(IConsumable food)`) een `IConsumable` verwacht. Elke klasse die de `IConsumable` interface implementeert, kunnen we dus geven als voer!

Elk dier kan eten. Implementeer `IFeedable` dus op `Animal` (zoals reeds gezegd) door de zopas vernoemde methode te noteren. Check in deze methode of het voedsel dat je het dier geeft giftig is of niet. Indien het giftig is, dan verminder zijn gezondheid (`Health`) met `30`. Is het geen giftig eten, dan vermeerdert zijn gezondheid met `10`.

Het enige wat ons nu nog rest is in de code behind de juiste logica schrijven. Zorg ervoor dat in `btnGiveFood_Click` er gecheckt wordt of in `lstGardenItems` een voederbaar item geselecteerd werd (dus eigenlijk de koe). In `lstHarvest` moet er een consumeerbaar item geselecteerd zijn. Indien aan beide voorwaarden voldaan wordt, dan geef je het voer aan het dier en verwijder je het geselecteerde voer uit `lstHarvest`.
Afhankelijk van het soort eten (giftig of niet), krijgt je dier gezondheid bij! Zorg bovendien dat de `UpdateGui()` ook nu gebeurt.

## The Endgame
Bekijk de code nogmaals opnieuw. Je schreef heel weinig code die heel veel doet. Wees trots op jezelf! Meeeeeuh!
