 var MyPlugin = {
  _isMobile: function()
  {
    if (/iPhone|iPad|iPod|Android/i.test(navigator.userAgent)) {
      return true;
    }
    return false;
  },
    
};

mergeInto(LibraryManager.library, MyPlugin);

