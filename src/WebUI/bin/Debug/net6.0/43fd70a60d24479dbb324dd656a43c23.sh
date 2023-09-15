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

ps 10136;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 10136 > /dev/null;
done;

for child in $(list_child_processes 10143);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/tunahanc/Desktop/testTaskFlying/src/WebUI/bin/Debug/net6.0/43fd70a60d24479dbb324dd656a43c23.sh;
