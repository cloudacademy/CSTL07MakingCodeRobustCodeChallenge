TARGET_DIR = ../challenge/one/

one:
	mkdir -p $(TARGET_DIR)
	cd ../src; tar -cf - . | tar -xf - -C $(TARGET_DIR)
	tar -cf - . | tar -xf - -C $(TARGET_DIR)
	cd $(TARGET_DIR); dotnet test