# RocketFlight | 11.2019, 8 Monate

Was habe ich gelernt:
- Collision mit 3 Achsen
- Sphere- und Box-Collider
- Einbindung von Liberies in Unity

Bei dieser Abgabe mussten wir die Mathemaikt Libery selber schreiben (Assets/Import/VektorenFormativ.dll) und in die Abgabe implimentieren.

Hierfür habe ich mir meine eigenen Collider gemacht, indem ich eine Basis Klasse gemacht habe und von dieser dann den Box- und Sphere Collider erben lassen habe. In diesen konnten man den Collider spezifisch Einstellen.

Weiter habe ich dann die Collisionsabfrage so weit vereinfacht, dass ich in einer Funktion zwei GameObjects mit einer beliebigen Anzahl an Collidern mit einander auf Collision prüfen konnte.

Für das Spielfeld habe ich mich entschieden in einem Bereich an zufälligen Position und mit zufälliger Größe die Hindernise zu spawnen.

Das Spiel musste 2,5D aufgebaut sein, da die Rotation in Unity mit Quaternions gemacht wird. Die Libery aber Rotation mit nur 3 Achsen erlaubt.
