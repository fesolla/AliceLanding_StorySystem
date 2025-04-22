### 1.名詞介紹
**Commit(提交)**：將當前的改動記錄下來

**Branch(分支)**：各個不同的狀態進度

**Merge(合併)**：將不同的分支組合為一起

**Pull(拉)**：將雲端的某一條分支拉到本地端

**Push(推)**：將本地端的分支內容更新到雲端

#### Commit：將當前的改動記錄下來
Git紀錄改動的基本單位。
每提一次Commit，就會在樹狀圖上多增加一個點。
在下圖中，test這個branch位在**789**這個提交上；main這個branch位在 **[Kira]專案設置** 這個提交上。

![kaaiWwJ](https://github.com/user-attachments/assets/b385008e-bfa4-41fa-9b9b-03eae09ff325)

#### Branch：各個不同的狀態進度
各個不同的專案狀態，方便不同的部門工作而不干擾。
在樹狀圖上，以方框標記各個branch的位置。

在下圖中，test2這個branch位在**abc**這個提交上，最新的提交會被放在最上面

![rcH1VZG](https://github.com/user-attachments/assets/95fa08a8-8e54-45bf-aaf8-ab43604f9bea)

只看test的樹狀圖

![kaaiWwJ](https://github.com/user-attachments/assets/c0135ab4-0bd4-4c27-bb9c-575b4c2ccd79)


只看test2的樹狀圖

![8SpHLQ6](https://github.com/user-attachments/assets/35e2fca2-5ae3-43e9-a302-407ac9d77c55)


#### Merge：將不同的分支組合為一起
將不同的Branch合併為同一條，本身也會形成一個新的Commit
下圖為將test2合併到test的圖示，在此之後，test會同時有**123** 、**456**、**789**、**abc** 這四個提交；而test2只有**abc**這個Commit。

![cDvFzhm](https://github.com/user-attachments/assets/5665abf0-89d3-43b4-a33f-ce84f9cc99b3)

==Merge會影響遠端資料，有一定風險，建議初期不要使用==

#### Pull：將雲端的某一條分支拉到本地端
將雲端的Branch拉到本地的電腦中。
==拉的是整條分支。==

#### Push：將本地端的分支內容更新到雲端
將本地的Branch推到雲端。
==注意：推的是整條分支==

### 2.Fork介紹
Fork是Git的圖形化UI，方便非程式人員操作。
業界多半使用SourceTree，不過頁面差不多，不過SourceTree有某個bug會導致無法開啟。

#### 工作流程
1.  Fetch
    點擊右上角，更新最新的分支狀況。
    原則上在只有自己的branch上面做工作，不會有其他的更改，不過為之後多人協作的狀況，還是建議養成好習慣。

    ![ioYagMa](https://github.com/user-attachments/assets/00c6bad1-e118-43d7-baf9-d32f482aea98)

3. Staged(暫存)
    在自己的專案當中進行修改，並且點選後，至`Local Changes`
    Git會自動偵測檔案有的改變，出現在staged當中
    ![LoVVtMB](https://github.com/user-attachments/assets/efbdd9df-7d69-4a27-8575-42beeebb7e49)
   
    點擊`Staged`，將變更暫存起來
    ![JBQzrKo](https://github.com/user-attachments/assets/cc8c6415-76cb-4282-aae6-16d145374af8)
   
5. Commit(提交)
     在右方欄位當中為這次的更變命名，寫上註解，點擊Commit完成提交。
    ![tpJwm0W](https://github.com/user-attachments/assets/66b12dbd-0cce-43c8-967c-635643e670d6)


### 在GitHub中建立新的Unity專案

1. **設定 Git LFS (Large File Storage)：**
    
    - 下載並安裝 Git LFS。
      https://git-lfs.com/
    - 在Git資料夾，右鍵選擇Open Git Bash here，執行以下指令：
        
        ```bash
        git lfs install
        ```
        
    - 建立 `.gitattributes` 檔案：
        
        ```bash
        echo > .gitattributes
        ```
        
    - 以編碼軟體編輯 `.gitattributes` 並新增以下內容（或根據需要進行客製化）：
        
        ```
        *.png filter=lfs diff=lfs merge=lfs -text
        *.jpg filter=lfs diff=lfs merge=lfs -text
        *.jpeg filter=lfs diff=lfs merge=lfs -text
        *.psd filter=lfs diff=lfs merge=lfs -text
        *.mp3 filter=lfs diff=lfs merge=lfs -text
        *.wav filter=lfs diff=lfs merge=lfs -text
        *.ogg filter=lfs diff=lfs merge=lfs -text
        *.m4a filter=lfs diff=lfs merge=lfs -text
        *.mp4 filter=lfs diff=lfs merge=lfs -text
        *.mov filter=lfs diff=lfs merge=lfs -text
        *.avi filter=lfs diff=lfs merge=lfs -text
        *.webm filter=lfs diff=lfs merge=lfs -text
        *.mkv filter=lfs diff=lfs merge=lfs -text
        *.zip filter=lfs diff=lfs merge=lfs -text
        *.rar filter=lfs diff=lfs merge=lfs -text
        *.7z filter=lfs diff=lfs merge=lfs -text
        *.unitypackage filter=lfs diff=lfs merge=lfs -text
        *.unity filter=lfs diff=lfs merge=lfs -text
        *.prefab filter=lfs diff=lfs merge=lfs -text
        *.anim filter=lfs diff=lfs merge=lfs -text
        *.controller filter=lfs diff=lfs merge=lfs -text
        *.shader filter=lfs diff=lfs merge=lfs -text
        *.cginc filter=lfs diff=lfs merge=lfs -text
        *.aif filter=lfs diff=lfs merge=lfs -text
        ```
        
    - 告訴 Git LFS 追蹤指定的檔案：
        
        ```bash
        git lfs track
        ```
        
    - 提交 `.gitattributes` 檔案：
        
        ```bash
        git add .gitattributes
        git commit -m "設定 Git LFS"
        ```
        
2. **建立 .gitignore：**
    
    - 建立 `.gitignore` 檔案：
        
        ```bash
        echo > .gitignore
        ```
        
    - 編輯 `.gitignore` 並新增以下內容（或根據需要進行客製化）：
        
        ```
        # Unity 產生的資料夾
        [Ll]ibrary/
        [Tt]emp/
        [Oo]bj/
        [Bb]uild/
        [Bb]uilds/
        [Ll]ogs/
        [Mm]emoryCaptures/
        
        # 使用者特定設定
        *.csproj
        *.unityproj
        *.sln
        *.suo
        *.tmp
        *.user
        *.userprefs
        *.pidb
        *.booproj
        *.svd
        
        # 作業系統產生的檔案
        .DS_Store
        Thumbs.db
        
        # Rider
        .idea/
        *.sln.iml
        
        # Visual Studio Code
        .vscode/
        
        # Crash Reports
        sysinfo.txt
        
        # 自動產生的 meta 和快取
        *.apk
        *.aab
        
        # 忽略 JetBrains Rider 快取
        .idea/
        
        # Unity Cloud Build
        .cloudbuild/
        
        # 其他
        *.swp
        ```
        
    - 提交 `.gitignore` 檔案：
        
        ```bash
        git add .gitignore
        git commit -m "新增 .gitignore 檔案"
        ```
        
3. **新增並提交初始專案檔案：**
    
    - 以UnityHub建立專案，暫存並提交。
        
        ```bash
        git add .
        ```
        
    - 提交變更：
        
        ```bash
        git commit -m "初始提交"
        ```      
    
    - 將您的本地儲存庫推送到遠端儲存庫(如果不是現在的版本，請創建新的分支推上去)：
        
        ```bash
        git push -u origin main
        ```
   
