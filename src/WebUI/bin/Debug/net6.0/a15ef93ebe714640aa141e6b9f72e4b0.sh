function list_child_processes(){
    local ppid=$1;
    local current_children=$(pgrep -P $ppid);
    local local_child;
    if [ $? -eq 0 ];
    then
        for current_child in $current_children
        do
          local_child=$current_child;
          list_child_processes $local_child;
          echo $local_child;
        done;
    else
      return 0;
    fi;
}

ps 5326;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 5326 > /dev/null;
done;

for child in $(list_child_processes 5337);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/tunahanc/Desktop/testTaskFlying/src/WebUI/bin/Debug/net6.0/a15ef93ebe714640aa141e6b9f72e4b0.sh;
