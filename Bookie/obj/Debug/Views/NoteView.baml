   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      H DBookie, Version=15196.2017.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Bookie.ViewModelsBookie.ViewModels 5	         Bookie.Views.NoteView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Pcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      6
viewModelsclr-namespace:Bookie.ViewModels     5	        � WindowStartupLocation$  CenterScreen=�5      (   "MahApps.Metro.Controls.MetroWindow   ShowMinButton .     ShowMaxRestoreButton .   � 
ResizeMode$ 	CanResize=�5         AccentColorBrush#���   5
      $��1q�5         EnableDWMDropShadow .    WindowTransitionsEnabled .   � Title$
 Note��5      $	��300��6$   $	��300��61    � 	Resources 5      %  Bookie.ViewModels.NoteViewModel  	ViewModel��%   &	         5   
   6#   5      .��5      �  � DataContext# [ 6   .+�5   
   ]� $��7,0,7,0q�6   ��. .+�5      �� $	��Top=�6   $��10q�6M   $��Add Note��6Y   $��80��6l   ��6*   �� *AddNoteCommand+6l   �� 5      $	��Top=�6   ��6)   �� *
NoteDate+�� 5      $��Center=�6   $��Bottom=�66   	 �� Orientation$	 
Horizontal=�6N   .+�5      �� $��5q�6=   $��Save Changes��6H   $��90��6_   ��6   �� *SaveNoteCommand+6_   �� 5      $��5q�6?   $��Remove��6J   $��90��6[   ��6   �� *RemoveNoteCommand+6[   5      �� 5      
���   �$	��0.7q�6)   ._�5      �� "
 �� VerticalScrollBarVisibility$

 Auto=�6   $ �� HorizontalScrollBarVisibility$ Disabled=�6=    �� TextWrapping$
 Wrap=�5      $��5q�6.   ���#FFFEC6��6O   �� *
NoteText+ �� Mode$ TwoWay=�5      5      5      5       