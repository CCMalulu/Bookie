   M S B A M L   `   `   `  ���� T  PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fT:clr-namespace:MahApps.Metro.Actions;assembly=MahApps.MetroMahApps.Metro.Actions  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35  �� MergedDictionaries �� Source   CustomFlyout ]�Name ��Name  MetroCircleButtonStyle �� RelativeSource �� AncestorType#    MahApps.Metro.Controls.Flyout �� Path �� Mode.  (System.Windows.Interactivity.Interaction   Triggers/  )System.Windows.Interactivity.EventTrigger	   	EventName.  (System.Windows.Interactivity.TriggerBase
   Actions/   )MahApps.Metro.Actions.SetFlyoutOpenAction   Value8  2System.Windows.Interactivity.TargetedTriggerAction   TargetObject J� OpacityMask j� Stretch !� Visual J� Clip � UseLayoutRounding �� Left
 �� Top �� Stretch ��Name  FlyoutHeaderFontSize �� Triggers �� Value �� Binding �� 
TargetName �� Property �� Value �� ScaleX �� Angle  FlyoutTemplate �� 
TargetType �Name'  !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup!   States   System.Windows.VisualState"   
Storyboard# ��Name$ g� 	BeginTime% �� TargetProperty& �� 
TargetName' O� KeyTime( �� 	KeySpline) O� Value* � FocusVisualStyle+ ��Name,    HeaderTemplate- �� Triggers. �� 
TargetType-	  'System.Windows.Input.KeyboardNavigation  FlyoutForegroundBrush  FlyoutBackgroundBrush�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     Bi:http://schemas.microsoft.com/expression/2010/interactivity  ;controls,http://metro.mahapps.com/winfx/xaml/controls   Factions:clr-namespace:MahApps.Metro.Actions;assembly=MahApps.Metro    �� $G Apack://application:,,,/MahApps.Metro;component/Styles/Colors.xaml?��� $F @pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml?�%j  &	       7  &	 �    '   �    7   7  �� .R�]� $ dpHeader��$��10,25,10,10q�$��Center=���. .+��� $	 nav��$
��Left=�#���  $��40��$��40��$��Segoe UI Symbol)�$��16(�$��Bottom=�����  �� "   $ CloseCommand�$ OneWay=�y���  �� *FindAncestor+"   $ CloseButtonVisibility�����  �� "   $ 
Foreground�   $	 Click��.
    .   ��  �� "   .���� $��20��$��15��
������� !� $
 Fill=� �� $��48��$��48��4 ��        � ��    � �� ���     ���         .  .+�F� $��31.6666��$��31.6667��$ 22.1666��$ 22.1667��$
 Fill=�
�������|��������<R��C�Z��@��=R��m5�����O���C��m5��Ѥ���n5��C0P������n5�H<R�����Z���CѬ<R\�������<R�� $ PART_BackButton��8��  $��15,0,0,0q�$��Center=����� y���  �� *FindAncestor+"   $ TitleVisibility� �� $
 Left�� �� *
Position+ �� "   .a��� $	 nav�� � ��$ Right=��� $ PART_BackButton�� �@��TextAlignment$ Right=��� $ PART_BackButton�� � ��$ 0,0,15,0q��� $	 nav�� �@�LayoutTransform �� $ -1Q��� $	 Top�� �� *
Position+ �� "   .a��� $ dpHeader�� � ��$ 10q��� $	 nav�� �@�LayoutTransform �� $	 -90Q��� $ Bottom�� �� *
Position+ �� "   .a��� $ dpHeader�� � ��$ 10q��� $	 nav�� �@�LayoutTransform �� $ 90Q��� "   .R�� $
 root��#��z��#��z��z�T�     .!   Default��  Hide��." �� $# HideStoryboard��.��U� $$ 00:00:00X�$8% 2(UIElement.RenderTransform).(TranslateTransform.X)�$
& root��.\��� $' 00:00:00.750��$( 0.25,1,0.05,1��$) 0Q�	hideFrame��U� $$ 00:00:00X�$8% 2(UIElement.RenderTransform).(TranslateTransform.Y)�$
& root��.\��� $' 00:00:00.750��$( 0.25,1,0.05,1��$) 0Q�
hideFrameY��U� $$ 00:00:00X�$% (UIElement.Opacity)�$
& root��.\��� $' 00:00:00.750��$( 0.25,1,0.05,1��$) 0Q�fadeOutFrame��  Show��." �� .��U� $$ 00:00:00X�$8% 2(UIElement.RenderTransform).(TranslateTransform.X)�$
& root��.\��� $' 00:00:00.750��$( 0.25,1,0.05,1��$) 0Q�	showFrame��U� $$ 00:00:00X�$8% 2(UIElement.RenderTransform).(TranslateTransform.Y)�$
& root��.\��� $' 00:00:00.750��$( 0.25,1,0.05,1��$) 0Q�
showFrameY��U� $$ 00:00:00X�$% (UIElement.Opacity)�$
& root��.\��� $' 00:00:00.750��$( 0.25,1,0.05,1��$) 1Q�  
HideDirect��." �� .��U� $$ 00:00:00X�$8% 2(UIElement.RenderTransform).(TranslateTransform.X)�$
& root��.\��� $' 0��$) 0Q�U� $$ 00:00:00X�$8% 2(UIElement.RenderTransform).(TranslateTransform.Y)�$
& root��.\��� $' 0��$) 0Q�U� $$ 00:00:00X�$% (UIElement.Opacity)�$
& root��.\��� $' 0��$) 0Q�  
ShowDirect��." �� .��U� $$ 00:00:00X�$8% 2(UIElement.RenderTransform).(TranslateTransform.X)�$
& root��.\��� $' 0��$) 0Q�U� $$ 00:00:00X�$8% 2(UIElement.RenderTransform).(TranslateTransform.Y)�$
& root��.\��� $' 0��$) 0Q�U� $$ 00:00:00X�$% (UIElement.Opacity)�$
& root��.\��� $' 0��$) 1Q�.+��� .u�]� |�.  * Z� .+��� $+ PART_Header��$	��Top=�$��Header��#��z, �� $+ PART_Content��$��Bottom=�- �� $	 Top�� �� *
Position+ �� *Self+.a��� $ PART_Header�� � ��$
 Left=��� $ PART_Content�� � ��$ Right=��� $ Bottom�� �� *
Position+ �� *Self+.a��� $ PART_Header�� � ��$
 Left=��� $ PART_Content�� � ��$ Right=��� ".   .���  � y�$ Hidden=���  �@	 ControlTabNavigation$ Cycle=���  �@	 TabNavigation$ Cycle=���  �@	 DirectionalNavigation$ Cycle=���  � ��$ Stretch=���  � ��$ Stretch=���  �@  HeaderTemplate8   ��  � ��8  ��  �@�FocusVisualStyle Z� ��  � ��# �  ��  � ��# �  