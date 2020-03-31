# LandscapeASP

Was kanns bisher?
	Die Anwendung setzt wie die Excel Anwendung Links zusammen und ruft auf Knopfdruck das Bild ab. Mit den Testvalues klappt es, allerdings weiss ich nicht, wie die Commands bei anderen Servern aussehen. Natürlich fehlt noch die meiste Funktionalität, aber hoffentlich hilft es jemandem bei der Umsetzung als Grundgerüst.


Wie sind (meine) Razorpages (grob!) aufgebaut?

	View: 
	Pages/Index.cshtml: Eigentliche Seite. Wird in _Layout.cshtml injiziert.
 	Pages/_Layout.chtml: Beschreibt die Basisstruktur aller Seiten: z.B. Home / Privacy Tabs


	Model:
	Models/RequestManager.cs: Hält die eingebenen Werte bzw. berechnet diese

	"Controller":
	Index.cshtml.cs: Bindeglied zwischen RequestManager und sichtbarer Seite  


ToDo:
Alle Kommentare die mit "!!!" beginnen zeigen stellen, an denen ich mir nicht ganz sicher war.
Ansonsten natürlich die ganzen Funktionalitäten, die ich nicht geschafft habe ;)
