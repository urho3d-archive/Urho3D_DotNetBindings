using System;
using System.Runtime.InteropServices;

public enum HorizontalAlignment
{
    HA_LEFT = 0,
    HA_CENTER,
    HA_RIGHT,
    HA_CUSTOM
}

public enum VerticalAlignment
{
    VA_TOP = 0,
    VA_CENTER,
    VA_BOTTOM,
    VA_CUSTOM
}

public class UIElement : Animatable
{
    public UIElement(IntPtr nativeInstance, Context context) : base(nativeInstance, context)
    {
    }

    // public UIElement(Context context) : this(UIElement_UIElement(context.NativeInstance), context) { }

    public T CreateChild<T>(string name = "", uint index = Math.M_MAX_UNSIGNED)
    {
        StringHash type = new StringHash(typeof(T).Name);
        IntPtr nativeChild = UIElement_CreateChild(NativeInstance, type, name, index);
        return (T)Activator.CreateInstance(typeof(T), nativeChild, context_);
    }
    
    public void SetPriority(int priority)
    {
        UIElement_SetPriority(NativeInstance, priority);
    }
    
    public void SetOpacity(float opacity)
    {
        UIElement_SetOpacity(NativeInstance, opacity);
    }
    
    public void SetAlignment(HorizontalAlignment hAlign, VerticalAlignment vAlign)
    {
        UIElement_SetAlignment(NativeInstance, hAlign, vAlign);
    }
    
    public void SetSize(int width, int height)
    {
        UIElement_SetSize(NativeInstance, width, height);
    }
    
    public void SetColor(Color color)
    {
        UIElement_SetColor(NativeInstance, ref color);
    }
    
    public void SetVerticalAlignment(VerticalAlignment align)
    {
        UIElement_SetVerticalAlignment(NativeInstance, align);
    }

    public void SetHorizontalAlignment(HorizontalAlignment align)
    {
        UIElement_SetHorizontalAlignment(NativeInstance, align);
    }
    
    public void AddChild(UIElement element)
    {
        UIElement_AddChild(NativeInstance, element.NativeInstance);
    }
    
    public void SetPosition(int x, int y)
    {
        UIElement_SetPosition(NativeInstance, x, y);
    }
    
    public int GetWidth()
    {
        return UIElement_GetWidth(NativeInstance);
    }

    public int GetHeight()
    {
        return UIElement_GetHeight(NativeInstance);
    }

    [DllImport(Consts.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr UIElement_CreateChild(IntPtr nativeInstance, StringHash type, string name = "", uint index = Math.M_MAX_UNSIGNED);

    [DllImport(Consts.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
    private static extern void UIElement_SetPriority(IntPtr nativeInstance, int priority);

    [DllImport(Consts.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
    private static extern void UIElement_SetOpacity(IntPtr nativeInstance, float opacity);

    [DllImport(Consts.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
    private static extern void UIElement_SetAlignment(IntPtr nativeInstance, HorizontalAlignment hAlign, VerticalAlignment vAlign);
    
    [DllImport(Consts.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
    private static extern void UIElement_SetSize(IntPtr nativeInstance, int width, int height);
    
    [DllImport(Consts.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
    private static extern void UIElement_SetColor(IntPtr nativeInstance, ref Color color);
    
    [DllImport(Consts.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
    private static extern void UIElement_SetHorizontalAlignment(IntPtr nativeInstance, HorizontalAlignment align);
    
    [DllImport(Consts.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
    private static extern void UIElement_SetVerticalAlignment(IntPtr nativeInstance, VerticalAlignment align);
    
    [DllImport(Consts.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
    private static extern void UIElement_AddChild(IntPtr nativeInstance, IntPtr element);
    
    [DllImport(Consts.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
    private static extern void UIElement_SetPosition(IntPtr nativeInstance, int x, int y);
    
    [DllImport(Consts.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
    private static extern int UIElement_GetWidth(IntPtr nativeInstance);

    [DllImport(Consts.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
    private static extern int UIElement_GetHeight(IntPtr nativeInstance);
}
