   M S B A M L   `   `   `  ���� T  PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  H DBookie, Version=15196.2017.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Bookie.ViewModelsBookie.ViewModels    Bookie.Views.NoteView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Pcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     6
viewModelsclr-namespace:Bookie.ViewModels       � WindowStartupLocation$  CenterScreen=�(   "MahApps.Metro.Controls.MetroWindow   ShowMinButton .     ShowMaxRestoreButton .   � 
ResizeMode$ 	CanResize=�   AccentColorBrush#���   $��1q�   EnableDWMDropShadow .    WindowTransitionsEnabled .   � Title$
 Note��$	��300��$	��300�� � 	Resources %  Bookie.ViewModels.NoteViewModel  	ViewModel��%   &	         .���  � DataContext# [ .+�]� $��7,0,7,0q���. .+��� $	��Top=�$��10q�$��Add Note��$��80������ *AddNoteCommand+�� $	��Top=����� *
NoteDate+�� $��Center=�$��Bottom=�	 �� Orientation$	 
Horizontal=�.+��� $��5q�$��Save Changes��$��90������ *SaveNoteCommand+�� $��5q�$��Remove��$��90������ *RemoveNoteCommand+�� 
���   �$	��0.7q�._��� "
 �� VerticalScrollBarVisibility$

 Auto=�$ �� HorizontalScrollBarVisibility$ Disabled=� �� TextWrapping$
 Wrap=�$��5q����#FFFEC6���� *
NoteText+ �� Mode$ TwoWay=�